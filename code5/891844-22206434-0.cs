    public object Convert(object value, Type targetType, object parameter, string language)
    {
        string filePath = value.ToString(); //get path to picture
        BitmapImage image = new BitmapImage(); //create bitmap image blank
        if (filePath.Contains("Assets")) //if standart picture
        {
            // Have it start processing the image in the background
            LoadImageFromAssetsLibrary(image);
            // Return the image. Even though it may not be done processing,
            // When it's done, it will fill the image with the source automatically
            return image;
        }
        else
        {
            // Same as above
            LoadImageFromString(image, filePath);
            return image;
        }
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
    private async Task LoadImageFromString(BitmapImage image, string path)
    {
        StorageFolder folder = KnownFolders.PicturesLibrary; //get folder
        StorageFile file = await folder.GetFileAsync(path); //find and read file
        //set source of file to image
        using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read))
        {
            await image.SetSourceAsync(stream);
        }
        // You don't need to return anything here. It is in effect using the 'image'
        // reference as an 'out' variable, and filling it with the data retrieved.
    }
