    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        var parameter = e.Parameter as StorageFile;
    
        if (parameter != null)
        {
            using (var strm = await parameter.OpenReadAsync())
            {
                finalImage.Source = new BitmapImage().SetSource(strm);
            }
        }
    }
