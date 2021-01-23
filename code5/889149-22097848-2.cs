    private void Surface_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsFirstPoint)
            {
                
                if (Surface.Children.Count > 0)
                {
                    var child = (from c in Surface.Children.OfType<FrameworkElement>()
                                 where "tempLine".Equals(c.Tag)
                                 select c).First();
                    if (child != null)
                    {
                        Surface.Children.Remove(child);
                    }
                }
                
               
                switch (activeShapeType)
                {
                    case ShapeType.line:
                        Line line = new Line() { Tag="tempLine", X1 = StartPoints.X, Y1 = StartPoints.Y, X2 = Mouse.GetPosition(Surface).X, Y2 = Mouse.GetPosition(Surface).Y, Stroke = Brushes.Black };
                        Surface.Children.Add(line);                      
                        
                        return;
                }
            }
        }
