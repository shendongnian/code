    private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        System.Windows.Point p = e.GetPosition(image);
        double pixelWidth = image.Source.Width;
        double pixelHeight = image.Source.Height;
        double x = pixelWidth * p.X / image.ActualWidth;
        double y = pixelHeight * p.Y / image.ActualHeight;
        MessageBox.Show(x + ", " + y);
    }
