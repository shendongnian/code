    FileInfo fileInfo = new FileInfo(file);
    BitmapImage bi = new BitmapImage();
    bi.BeginInit();
    bi.UriSource = new Uri(file, UriKind.Relative);
    bi.DecodePixelWidth = 20;
    bi.EndInit();
    var button = new KinectTileButton
    {
        Label = System.IO.Path.GetFileNameWithoutExtension(file),
        Background = new ImageBrush(bi),
        Tag = file
    };
    **button.Click += KinectTileButtonClick;**
    var selectionDisplay = new SelectionDisplay(button.Label as string, button.Tag as string);
    this.wrapPanel.Children.Add(button);
