    public override bool IsValid(object value)
    {
        var file = value as HttpPostedFileBase;
        if (file == null)
        {
            return false;
        }
        if (file.ContentLength > 1 * 1024 * 1024)
        {
            return false;
        }
        try
        {
            using (var img = Image.FromStream(file.InputStream))
            {
                return img.RawFormat.Equals(ImageFormat.Png);
            }
        }
        catch { }
        return false;
    }
