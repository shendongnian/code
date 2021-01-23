      var parent = VisualTreeHelper.GetParent(child);
      var parentAsPanel = parent as Panel;
      if (parentAsPanel != null)
      {
          parentAsPanel.Children.Remove(child);
      }
      var parentAsContentControl = parent as ContentControl;
      if (parentAsContentControl != null)
      {
          parentAsContentControl.Content = null;
      }
      var parentAsDecorator = parent as Decorator;
      if (parentAsDecorator != null)
      {
          parentAsDecorator.Child = null;
      }
