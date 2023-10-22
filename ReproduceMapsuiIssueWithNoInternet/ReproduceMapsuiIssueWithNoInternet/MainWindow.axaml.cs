using Avalonia.Controls;
using Mapsui.Layers;
using Mapsui.Limiting;
using Mapsui.Styles;
using Mapsui;

namespace ReproduceMapsuiIssueWithNoInternet
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var mapControl = new Mapsui.UI.Avalonia.MapControl();
			mapControl.Map = CreateMapRobloo();
			Content = mapControl;
		}

		public static Map CreateMapRobloo()
		{
			var map = new Map()
			{
				BackColor = new Color(0xFF, 0xFF, 0xFF, 0xFF)
			};
			map.Navigator.Limiter = new ViewportLimiterKeepWithinExtent();

			// Add the map tiles layer (actual mapping data)
			var tileLayer = new Mapsui.Tiling.Layers.TileLayer(
				BruTile.Predefined.KnownTileSources.Create(
					BruTile.Predefined.KnownTileSource.BingRoads,
					"I don't know the key"));
			map.Layers.Add(tileLayer);

			// Dont' know what to do with this: this.pins.Clear()

			var pinsLayer = new WritableLayer
			{
				Name = "Pins Layer",
				Style = new VectorStyle
				{
					Fill = new Brush(new Color(0xF4, 0x64, 0x11, 0xFF)),
					Outline = new Pen(Color.White, 1)
				}
			};
			map.Layers.Add(pinsLayer);

			return map;
		}
	}
}