     CheckBox checkbox = new CheckBox();
     checkbox.Content = "Content";
     checkbox.Height = 50;
     checkbox.Width = 100;
     checkbox.IsChecked = true;
     checkbox.HorizontalAlignment = HorizontalAlignment.Left;
        
     VisualBrush vb = new VisualBrush(checkbox);
     drawingContext.DrawRectangle(vb, null, new Rect(50, 50, 100, 50));
