    byte[] imageData;
    
    // Create the byte array.
    var originalImage = Image.FromFile(@"C:\original.jpg");
    using (var ms = new MemoryStream())
    {
        originalImage.Save(ms, ImageFormat.Jpeg);
        imageData = ms.ToArray();
    }
    
    // Convert back to image.
    using (var ms = new MemoryStream(imageData))
    {
        Image image = Image.FromStream(ms);
        image.Save(@"C:\newImage.jpg");
    }
