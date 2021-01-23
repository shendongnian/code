    Polygon areaOfInterset;
    void CreateCircle(double radius)
            {
                var point = new MapPoint(Your Lat and Long);// This will be user lat and long on which you want to draw a circle
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
                areaOfInterset = new Polygon { Rings = rings};
    
              
            }
