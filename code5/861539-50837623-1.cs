    private static string ImageToBase64(Image image)
    {
        try
        {
            var imageStream = new MemoryStream();
            image.Save(imageStream, System.Drawing.Imaging.ImageFormat.Bmp);
            imageStream.Position = 0;
            var imageBytes = imageStream.ToArray();
            var ImageBase64 = Convert.ToBase64String(imageBytes);
            return ImageBase64;
        }
        catch (Exception ex)
        {
            return "Error converting image to base64!";
        }
    }
