        private Brush geoBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF0A0A10"));
        private Pen geoPen = new Pen(Brushes.LightSkyBlue, 0.5);
        private DropShadowEffect geoDropShadow = new DropShadowEffect
        {
            Color = Brushes.LightSteelBlue.Color,
            BlurRadius = 8.0,
            ShadowDepth = 0.0
        };
        private DrawingVisual GeoVisual = null;
        private void UpdateGeoLines()
        {
            MapProjectionViewModel map = this.DataContext as MapProjectionViewModel;
            if (map != null)
            {
                DrawingVisual visual = new DrawingVisual();
                using (DrawingContext dc = visual.RenderOpen())
                {
                    foreach (var item in map.GeoLines)
                    {
                        if (item.Points.Count > 1)
                        {
                            List<Point> points = new List<Point>();
                            foreach (var p in item.Points)
                            {
                                Point point = new Point(
                                p.X * canvas.ActualWidth,
                                p.Y * canvas.ActualHeight);
                                points.Add(point);
                            }
                            StreamGeometry geom = new StreamGeometry();
                            using (StreamGeometryContext gc = geom.Open())
                            {
                                Point p1 = points[0];
                                // Start new object, filled=true, closed=true
                                gc.BeginFigure(p1, true, true);
                                // isStroked=true, isSmoothJoin=true
                                gc.PolyLineTo(points, true, false);
                            }
                            geom.Freeze();
                            dc.DrawGeometry(geoBrush, geoPen, geom);
                        }
                    }
                }
                visual.Effect = geoDropShadow;
                visual.Opacity = 0.8;
                canvas.Visuals.Remove(GeoVisual);
                canvas.Visuals.Add(visual);
                GeoVisual = visual;
            }
        }
