    public object Any(ImageAsBytes request)
    {
        using (var image = new Bitmap(100, 100))
        {
            using (var g = Graphics.FromImage(image))
            {
                g.Clear(request.Format.ToImageColor());
            }
            using (var m = new MemoryStream())
            {
                image.Save(m, request.Format.ToImageFormat());
                var imageData = m.ToArray(); //buffers
                return new HttpResult(imageData, request.Format.ToImageMimeType());
            }
        }
    }
