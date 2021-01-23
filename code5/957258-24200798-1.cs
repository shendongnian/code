    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Maps.Controls;
    using System;
    using System.Windows;
    
    namespace SampleApp
    {
        public partial class MainPage : PhoneApplicationPage
        {
            public MainPage()
            {
                this.InitializeComponent();
    
                MyMap.Loaded += (s, e) =>
                {
                    string tileURL = "http://mesonet.agron.iastate.edu/cache/tile.py/1.0.0/nexrad-n0q-900913/{zoomLevel}/{x}/{y}.png?" + DateTime.Now.ToString();
                    MyMap.TileSources.Add(new TileSource(tileURL));
                };
    		}
        }
    }
