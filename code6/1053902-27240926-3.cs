    public object Any(ImageAsCustomResult request)
    {
        var image = new Bitmap(100, 100);
        using (var g = Graphics.FromImage(image))
        {
            g.Clear(request.Format.ToImageColor());
            return new ImageResult(image, request.Format.ToImageFormat()); 
        }
    }
