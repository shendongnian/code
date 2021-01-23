        public bool IsFirstPoint = true;
        public Point StartPoint;
        public enum ShapeType
        {
            line,
            circle, 
            rectangle
        }
        public ShapeType activeShapeType = ShapeType.line;
        
        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsFirstPoint)
            {
                StartPoint = (Mouse.GetPosition(Surface));
                IsFirstPoint = false;
            }
            else
            {
                switch (activeShapeType)
                {
                    case ShapeType.line:
                        Line line = new Line() { X1 = StartPoint.X, Y1 = StartPoint.Y, X2 = Mouse.GetPosition(Surface).X, Y2 = Mouse.GetPosition(Surface).Y, Stroke = Brushes.Black };
                        Surface.Children.Add(line);
                        break;
                    case ShapeType.rectangle:
                       /*Your code to draw rectangle here*/
                       break;
                }
                IsFirstPoint = true;
            }
        }
        private void Surface_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsFirstPoint = true;
        }
