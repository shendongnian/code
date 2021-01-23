    for (int i = 0; i < illustrations.Count; i++)
    {
        String path = illustrations[i].printVersions.Last<String>();
        BitmapImage bmp = new BitmapImage(new Uri(path));
        Controls.SingleIllustrationViewer iv = new Controls.SingleIllustrationViewer();
        iv.VerticalAlignment = System.Windows.VerticalAlignment.Top;
        iv.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
        iv.Margin = new Thickness(50, 0, 0, 20); //50 px to the left, 20 px to the next child 
        iv.Image = bmp;
        stackPanel1.Children.Add(iv);
     }
