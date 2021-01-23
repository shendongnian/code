    public object Any(ImageAsStream request)
    {
        using (var image = new Bitmap(100, 100))
        {
            using (var g = Graphics.FromImage(image))
            {
                g.Clear(request.Format.ToImageColor());
            }
            var ms = new MemoryStream();
            image.Save(ms, request.Format.ToImageFormat());
            return new HttpResult(ms, request.Format.ToImageMimeType()); 
        }
    }
