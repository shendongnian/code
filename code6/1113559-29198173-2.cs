    public BitmapSource GetSourceForOnRender()
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        var bitmap = new BitmapImage();
        using (var stream =
            assembly.GetManifestResourceStream("KisserConsole.someImage.png"))
        {
            bitmap.BeginInit();
            bitmap.StreamSource = stream;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
        }
        return bitmap;    
    }
