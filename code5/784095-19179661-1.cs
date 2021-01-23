    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        var parameter = e.Parameter as StorageFile;
    
        if (parameter != null)
        {
            using (var strm = await parameter.OpenReadAsync())
            {
                var bmp = new BitmapImage();
                bmp.SetSource(strm);
                finalImage.Source = bmp;
            }
        }
    }
