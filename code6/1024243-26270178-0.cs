    Rectangle swatch = new System.Windows.Shapes.Rectangle();
                swatch.Width = 50;
                swatch.Height = 50;
    
                DrawingBrush blackBrush = new DrawingBrush();
                GeometryDrawing backgroundSquare = new GeometryDrawing(Brushes.White, null,
                    new RectangleGeometry(new Rect(0, 0, 25, 25)));
                GeometryGroup gGroup = new GeometryGroup();
                gGroup.Children.Add(new RectangleGeometry(new Rect(25, 0, 25, 25)));
                GeometryDrawing checkers = new GeometryDrawing(Brushes.Black, null, gGroup);
    
                DrawingGroup checkersDrawingGroup = new DrawingGroup();
                checkersDrawingGroup.Children.Add(backgroundSquare);
                checkersDrawingGroup.Children.Add(checkers);
    
                blackBrush.Drawing = checkersDrawingGroup;            
                swatch.Fill = blackBrush;
    
                brdrect.Children.Add(swatch);
