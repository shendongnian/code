    private async void DownloadImagefromServer(string imgUrl)
    {
        Debug.WriteLine("Attempting to Get Image from Server...");
        WebClient client = new WebClient();
        var result = await client.OpenRead(new Uri(imgUrl, UriKind.Absolute));
        BitmapImage bitmap = new BitmapImage();
        bitmap.SetSource(result);
        //img.Source = bitmap;
        ... rest of your code from OpenReadCompleted goes here
    }
