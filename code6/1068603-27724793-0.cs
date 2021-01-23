        StorageFolder pictureFolder = KnownFolders.PicturesLibrary; //or another folder
        IReadOnlyList<IStorageItem> nameList = await pictureFolder.GetItemsAsync();
        foreach (var item in nameList)
        {
            if (item is StorageFile)
            {
                if (item.Name.Substring(item.Name.Length - 4, 3).ToLower() == "jpeg" || item.Name.Substring(item.Name.Length - 3, 3).ToLower() == "jpg" || item.Name.Substring(item.Name.Length - 3, 3).ToLower() == "png")
                {
                    //add photo to listView
                    Image image = new Image();
                    StorageFile file = await pictureFolder.GetFileAsync(item.Name);
                    IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    BitmapImage b = new BitmapImage();
                    b.SetSource(fileStream);
                    if (b.DecodePixelHeight >= b.DecodePixelWidth)
                    {
                        b.DecodePixelWidth = b.DecodePixelHeight / 100;
                        b.DecodePixelHeight = 100;
                    }
                    else
                    {
                        b.DecodePixelHeight = b.DecodePixelWidth / 100;
                        b.DecodePixelWidth = 100;
                    }
                    image.Source = b;
                    listView.Items.Add(image);
                }
            }
        }
