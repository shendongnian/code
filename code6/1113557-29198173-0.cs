    public BitmapSource GetSourceForOnRender()
    {
        var myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
        var bitmap = new BitmapImage();
        using (var stream =
            myAssembly.GetManifestResourceStream("KisserConsole.someImage.png"))
        {
            bitmap.BeginInit();
            bitmap.StreamSource = stream;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
        }
        return bitmap;    
    }
