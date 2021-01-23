    private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
    {
       var ellipse = sender as Ellipse;
       if (ellipse != null && e.ClickCount == 2)
       {
          elliplse.Stroke = "Red";
       }
    }
