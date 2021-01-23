    byte[] jpgImageBytes = null;
    using (var origImageStream = new MemoryStream(image))
    using (var jpgImageStream = new MemoryStream())
    {
        var jpgImage = System.Drawing.Image.FromStream(origImageStream);
        jpgImage.Save(jpgImageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        jpgImageBytes = jpgImageStream.ToArray();
        jpgImage.Dispose();
    }
