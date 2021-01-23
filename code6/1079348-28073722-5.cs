    var bytes = Convert.FromBase64String(base54Img);
    using (var imageFile = new MemoryStream(bytes))
    {
        Image img = Image.FromStream(imageFile);
        img.Save(imageFile, System.Drawing.Imaging.ImageFormat.Png);
    }
