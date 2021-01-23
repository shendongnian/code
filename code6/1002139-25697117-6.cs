        void test()
        {
            var geometry = new PathGeometry(new[] { new PathFigure(new Point(0,0), new[] {
                                                        new LineSegment(new Point(300, 300), true),
                                                        new LineSegment(new Point(300, 0), true),
                                                    }, false) });
            Rect clipRect= new Rect(10, 10, 180, 180);
            path.Data = ClipGeometry(geometry, clipRect);
            path2.Data = geometry;
            pathClip.Data = new RectangleGeometry(clipRect);
        }
