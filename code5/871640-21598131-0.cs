    void CreateCircleWithRadius(double radius)
            {
                var point = new MapPoint(Your Lat and Long);
                var graphic = new Graphic();
                var circle = new ESRI.ArcGIS.Client.Geometry.PointCollection();
                int i = 0;
    
                while (i <= 360)
                {
                    double degree = (i * (Math.PI / 180));
    
                    double x = point.X + Math.Cos(degree) * radius;
                    double y = point.Y + Math.Sin(degree) * radius;
                    circle.Add(new MapPoint(x, y));
                    i++;
                }
                var rings = new ObservableCollection<ESRI.ArcGIS.Client.Geometry.PointCollection> { circle };
                var polygon = new Polygon { Rings = rings};
    
                var simpleFillSymbol = new SimpleFillSymbol
                {
                    Fill = new SolidColorBrush(Colors.Transparent),
                    BorderBrush = new SolidColorBrush(Colors.Red),
                    BorderThickness = 3
                };
    
                graphic.Geometry = polygon;
                graphic.Symbol = simpleFillSymbol;
                ((GraphicsLayer)ViewModel.MapLayers["MyGraphicsLayer"]).Graphics.Add(graphic);
            }
