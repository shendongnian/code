    public void AddImageToContainer(string path, Panel parent)
    {
        var bmap = new BitmapImage();
        bmap.BeginInit();
        bmap.UriSource = new Uri(_appPath + path, UriKind.RelativeOrAbsolute);
        bmap.EndInit();
        var img = new Image
        {
            Source = bmap,
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            Stretch = Stretch.None
        };
        parent.Children.Add(img);
    }
