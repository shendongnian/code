        void test()
        {
            var radius = 1.0;
            var figures = new List<LineSegment>();
            for (int i = 0; i < 2000; i++, radius += 0.1)
            {
                var segment = new LineSegment(new Point(radius * Math.Sin(i), radius * Math.Cos(i)), true);
                segment.Freeze();
                figures.Add(segment);
            }
            var geometry = new PathGeometry(new[] { new PathFigure(figures[0].Point, figures, false) });
            Rect clipRect= new Rect(10, 10, 180, 180);
            path.Data = ClipGeometry(geometry, clipRect);
            path2.Data = geometry;
            pathClip.Data = new RectangleGeometry(clipRect);
        }
