    public void CreateRectangle(int groupCount)
            {
                Rectangle swatch = new System.Windows.Shapes.Rectangle();
                swatch.Width = 50;
                swatch.Height = 50;
                double groupsize = 100 / groupCount;
                DrawingBrush blackBrush = new DrawingBrush();
                DrawingGroup checkersDrawingGroup = new DrawingGroup();
                //Considering 3 as groupCount
                List<SolidColorBrush> brushes = new List<SolidColorBrush>() { Brushes.Black, Brushes.White,Brushes.Red };
                double location = 0;
                for (int i = 0; i < groupCount; i++)
                {                
                    GeometryDrawing drawing = new GeometryDrawing(brushes[i] , null,
                        new RectangleGeometry(new Rect(0, location,groupsize,groupsize)));
                    checkersDrawingGroup.Children.Add(drawing);
                    location += groupsize;
                }
                blackBrush.Drawing = checkersDrawingGroup;
                swatch.Fill = blackBrush;
    
                brdrect.Children.Add(swatch);
            }
