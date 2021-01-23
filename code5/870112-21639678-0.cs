	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	using DotSpatial.Controls;
	using DotSpatial.Data;
	using DotSpatial.Topology;
	namespace WindowsFormsApplication4
	{
		public partial class Form1 : Form
		{
			private Extent env;
			IMapLayer layer;
			public Form1()
			{
				InitializeComponent();
			}
			private void buttonOpen_Click(object sender, EventArgs e)
			{
				layer = map1.AddLayer();
			}
			private void buttonZoomToPoints_Click(object sender, EventArgs e)
			{
				Extent ext = layer.Extent;
				ext.ExpandToInclude(env);
				map1.ViewExtents = ext;
			}
			private void addLayer_Click(object sender, EventArgs e)
			{
				// Add
				Coordinate c = new Coordinate(1, 1);
				Coordinate c1 = new Coordinate(2, 2);
				FeatureSet fs = new FeatureSet(FeatureType.Point);
				fs.AddFeature(new DotSpatial.Topology.Point(c));
				fs.AddFeature(new DotSpatial.Topology.Point(c1));
				env = fs.Extent;
				MapPointLayer layer = new MapPointLayer(fs);
				map1.MapFrame.DrawingLayers.Add(layer);
				map1.Refresh();
			}
		}
	}
