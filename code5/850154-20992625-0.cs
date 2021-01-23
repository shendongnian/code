     private void CanvasArt_MouseMove(object sender, MouseEventArgs e)
     {
         if (drawing)
         {
              Point current = e.GetPosition((UIElement)sender);
              Line line = new Line() { X1 = start.X, Y1 = start.Y, X2 = current.X, Y2 = current.Y };
              line.Tag = GetNextIdValue();
              line.Stroke = new SolidColorBrush(Colors.Red);
              line.StrokeThickness = 1;
              CanvasArt.Children.Add(line);
              start = current;
         }
     }
     private void ButtonSave_Click(object sender, RoutedEventArgs e)
     {                
         this.DialogResult = true;
         ExtendedImage MyCanvasImage = CanvasArt.ToImage();
         // Retrieve line from CanvasArt.Children
         Line line = (from c in CanvasArt.Children
                      where c.Tag.ToString() == "SomeValue"
                      select c).FirstOrDefault() as Line;
         CanvasArt.Children.Remove(line);
     }
