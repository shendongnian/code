    var image = new Image();
    var source = new BitmapImage();
    source.BeginInit();
    source.CacheOption = BitmapCacheOption.OnLoad;
    
    // Create a new stream without disposing it!
    source.StreamSource = new MemoryStream();
    
    using (var filestream = new FileStream(filename, FileMode.Open))
    {
       // Copy the file stream and set the position to 0
       // or you will get a FileFormatException
       filestream.CopyTo(source.StreamSource);
       source.StreamSource.Position = 0;
    }
    
    source.EndInit();
    image.Source = source;
