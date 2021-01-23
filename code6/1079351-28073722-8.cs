    var bytes = Convert.FromBase64String(base64Img);
    using (var imageFile = new MemoryStream(bytes))
    {
        Image img = Image.FromStream(imageFile);
        img.Save(imageFile, System.Drawing.Imaging.ImageFormat.Png);
    }
