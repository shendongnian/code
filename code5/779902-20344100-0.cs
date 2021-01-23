     public string YourMethod(string yoursUri)
     {
        BitmapImage image=new BitmapImage();
        WebClient client = new WebClient();
        client.OpenReadCompleted += async (o, args) =>
        {
            Stream stream = new MemoryStream();
            await args.Result.CopyToAsync(stream);
            image.SetSource(stream);
        };
        client.OpenReadAsync(new Uri(yoursUri));//if passing object than you can write myObj.yoursUri
        return image;
    }
