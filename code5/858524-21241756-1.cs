    public void AddImageToContainer(string path, Panel parent)
    {
        var bmap = new BitmapImage(new Uri(_appPath + path, UriKind.RelativeOrAbsolute));
        var img = new Image
        {
            Source = bmap,
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            Stretch = Stretch.None
        };
        parent.Children.Add(img);
    }
