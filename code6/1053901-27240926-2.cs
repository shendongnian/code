    public void Any(ImageWriteToResponse request)
    {
        using (var image = new Bitmap(100, 100))
        {
            using (var g = Graphics.FromImage(image))
            {
                g.Clear(request.Format.ToImageColor());
            }
            base.Response.ContentType = request.Format.ToImageMimeType();
            image.Save(base.Response.OutputStream, request.Format.ToImageFormat());
            base.Response.Close();
        }
    }
