    FileOpenPicker open = new FileOpenPicker();
    open.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
    open.ViewMode = PickerViewMode.Thumbnail;
    
    // Filter to include a sample subset of file types
    open.FileTypeFilter.Clear();
    open.FileTypeFilter.Add(".bmp");
    open.FileTypeFilter.Add(".png");
    open.FileTypeFilter.Add(".jpeg");
    open.FileTypeFilter.Add(".jpg");
    
    // Open a stream for the selected file
    StorageFile file = await open.PickSingleFileAsync();
    
    // ImageSource im = (new Uri (file.Path));
    var bmp = new BitmapImage();
    using (var strm = await file.OpenReadAsync())
    {
        bmp.SetSource(strm);
        ChildPic.Source = bmp;
    }
