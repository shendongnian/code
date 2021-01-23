    public static BitmapSource BitmapFromBase64(string b64string)
    {
        var bytes = Convert.FromBase64String(b64string);
        using (var stream = new MemoryStream(bytes))
        {
            return BitmapFrame.Create(stream,
                BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }
    }
