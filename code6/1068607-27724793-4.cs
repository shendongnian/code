    StorageFolder pictureFolder = KnownFolders.PicturesLibrary; //or another folder
    IReadOnlyList<IStorageItem> nameList = await pictureFolder.GetItemsAsync();
    var bitmapImages = new ObservableCollection<BitmapImage>();
    
    foreach (var item in nameList)
    {
        if (item is StorageFile)
        {
            if (item.Name.Substring(item.Name.Length - 4, 3).ToLower() == "jpeg" || item.Name.Substring(item.Name.Length - 3, 3).ToLower() == "jpg" || item.Name.Substring(item.Name.Length - 3, 3).ToLower() == "png")
            {
                Image image = new Image();
                StorageFile file = await pictureFolder.GetFileAsync(item.Name);
                IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.SetSource(fileStream);
                if (bitmapImage.DecodePixelHeight >= bitmapImage.DecodePixelWidth)
                {
                    bitmapImage.DecodePixelWidth = bitmapImage.DecodePixelHeight / 100;
                    bitmapImage.DecodePixelHeight = 100;
                }
                else
                {
                    bitmapImage.DecodePixelHeight = bitmapImage.DecodePixelWidth / 100;
                    bitmapImage.DecodePixelWidth = 100;
                }
                bitmapImages.Add(bitmapImage);
            }
        }
    }
