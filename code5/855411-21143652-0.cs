    private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        // Console.WriteLine("Clicked");
         if (e.ButtonState == MouseButtonState.Pressed)
          {
              offset = e.GetPosition(sender as FrameworkElement);
              Console.WriteLine("Offset: " + offset.ToString());
              currentPoint = e.GetPosition(sender as FrameworkElement); //  Change here
          }
    }
    
    private void Canvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
    {
          if (e.LeftButton == MouseButtonState.Pressed)
          {
                Line line = new Line();
                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(sender as FrameworkElement).X; //  Change here
                line.Y2 = e.GetPosition(sender as FrameworkElement).Y; //  Change here
    
                currentPoint = e.GetPosition(sender as FrameworkElement); //  Change here
    
                canvas.Children.Add(line);
          }
    }
