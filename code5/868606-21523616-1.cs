     private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e) {
          
          Canvas.SetTop(MouseRectangle, 
                        e.GetPosition(DrawingCanvas).Y - MouseRectangle.Height/2);
          Canvas.SetLeft(MouseRectangle,
                         e.GetPosition(DrawingCanvas).X - MouseRectangle.Width /2);
        }
