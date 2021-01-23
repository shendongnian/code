    private void MouseLeftButtonUp(object sender, MouseButtonEventArgs args)
    {
        var image = (Image)sender;
        string key = image.Tag as string; 
        // ...
    }
