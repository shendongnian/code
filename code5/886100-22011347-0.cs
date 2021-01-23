    System.Windows.Media.ImageSource iconSource;
    using (System.Drawing.Icon sysicon = System.Drawing.Icon.ExtractAssociatedIcon(FilePath))
    {
        iconSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
        sysicon.Handle,
        System.Windows.Int32Rect.Empty,
        System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
    }
    return iconSource;
