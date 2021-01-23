    public static BitmapSource BitmapImageFromFile(string filepath)
    {
        var bi = new BitmapImage();
                        
        using (var fs = new FileStream(filepath, FileMode.Open))
        {
            bi.BeginInit();                
            bi.StreamSource = fs;                
            bi.CacheOption = BitmapCacheOption.OnLoad;
            bi.EndInit();
        }
        bi.Freeze(); //Important to freeze it, otherwise it will still have minor leaks
        return bi;
    }
