    <!-- create the container in xaml -->
    <Image x:Name="myImage"></Image>
    // this function loads an image from isolated storage and returns a bitmap
    private static BitmapImage GetImageFromIsolatedStorage(string imageName)
    {
        var bimg = new BitmapImage();
        using (var iso = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (var stream = iso.OpenFile(imageName, FileMode.Open, FileAccess.Read))
            {
                bimg.SetSource(stream);
            }
        }
        return bimg;
    }
    // load the first image in recent images
    BitmapImage first = GetImageFromIsolatedStorage(recent_images[0]);
    // set the BitmapImage as the source of myImage to display it on the screen
    this.myImage.Source = first;
