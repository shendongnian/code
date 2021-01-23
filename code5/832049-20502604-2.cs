    private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
    {
       if (ellipse as sender == null || e.ClickCount < 2)
          return;
       var ellipse = (Ellipse)sender;
       ellipse.Stroke = System.Windows.Media.Brushes.Red;
    }
