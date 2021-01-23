    ...........
      Button btn = new Button();
            btn.Name = "Cancel";
            btn.Content = "Cancel";
            btn.Background = Brushes.Red;
            btn.Width = 50;
            btn.Height = 25;
            btn.RenderTransform = new System.Windows.Media.TranslateTransform(pe.InkCanvas.ActualWidth-btn.Width,topmargin);
         
            btnCancel = btn;
            pe.InkCanvas.Children.Add(btnCancel);
