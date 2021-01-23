    var images = resourceSet.Cast<DictionaryEntry>()
				.Where(x => x.Value is Bitmap)
				.Select(x => Convert(x.Value as Bitmap))
				.ToList();
    public BitmapImage Convert(Bitmap value)
    {
        var ms = new MemoryStream();
        value.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
        var image = new BitmapImage();
        image.BeginInit();
        ms.Seek(0, SeekOrigin.Begin);
        image.StreamSource = ms;
        image.EndInit();
    
        return image;
    }
