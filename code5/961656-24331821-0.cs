    private void Image_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        var image = (Image)sender;
        Trace.TraceInformation("Size = {0} x {1}", image.ActualWidth, image.ActualHeight);
    }
