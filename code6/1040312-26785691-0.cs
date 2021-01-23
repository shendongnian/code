    private void SaveImage()
    {
        TChart chart = new TChart();
        JPEGFormat jpegFormat = chart.Export.Image.JPEG;
        Line line = new Line();
        line.FillSampleValues();
        chart.Series.Add(line);
        jpegFormat.Width = 1024;
        jpegFormat.Height = 340;
        jpegFormat.Quality = 100;
        chart.AfterDraw += OnAfterDraw;
        chart.DoInvalidate();
        jpegFormat.Save("C:\\Temp\\steemachart.jpg");
    }
    private void OnAfterDraw(object sender, Graphics3D g)
    {
        BitmapSource bitmap = new BitmapImage(new Uri("pack://application:,,,/button.png"));
        g.Draw(new Rect(0, 0, bitmap.Width, bitmap.Height), bitmap, true);
    }
