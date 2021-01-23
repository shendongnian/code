    GeometryDrawing backgroundSquare = new GeometryDrawing(Brushes.White, null,
                    new RectangleGeometry(new Rect(0, 0, 25, 25)));
                GeometryGroup gGroup = new GeometryGroup();
                gGroup.Children.Add(new RectangleGeometry(new Rect(0, 25, 25, 25)));
                GeometryDrawing checkers = new GeometryDrawing(Brushes.Black, null, gGroup);
