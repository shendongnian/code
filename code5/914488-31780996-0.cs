        if (menu_item.Header as FrameworkElement != null)
        {
            FrameworkElement header = (FrameworkElement)menu_item.Header;
    
            // Create the visual brush based on the UserControl
            VisualBrush headerVisualBrush = new VisualBrush(header);
            headerVisualBrush.Stretch = Stretch.Uniform;
    
            // Draw using the visual brush in the rect
            double contentSize = distance / 2;
            drawingContext.DrawRectangle(headerVisualBrush, null, new Rect(center.X - contentSize / 2.0, center.Y - contentSize / 2.0, contentSize, contentSize));
      }
      else if (menu_item.Header as String != null)
      {
    
      }
