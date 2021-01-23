    private void LoadImage()
    {
        // make a request to get the image. 
        // Use your flavor of choice, WebRequest, HttpClient, WebClient
        
        Stream image = GetImageFromMyFavoriteHttp;
        using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (var file = storage.CreateFile("Image.jpg"))
            {
                image.CopyTo(file);
            }
        }
        Deployment.Current.Dispatcher.BeginInvoke(() =>
        {
            var bitmap = new BitmapImage();
            bitmap.SetSource(image);
            Image = bitmap;
        });
    }
