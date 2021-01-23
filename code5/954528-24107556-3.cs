    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(data))
    {
        var imageSource = new BitmapImage();
        imageSource.BeginInit();
        imageSource.StreamSource = ms;
        imageSource.EndInit();
    
        // Assign the Source property of your image
        yourImage.Source = imageSource;
    }
       
