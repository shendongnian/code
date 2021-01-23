    byte[] ida = new byte[length];
    using (FileStream fs = File.OpenRead("Escudos.bcf"))
    {
        fs.Seek(start, SeekOrigin.Begin);
        fs.Read(ida, 0, length);
    }
    using (MemoryStream ms = new MemoryStream(ida))
    {
        Image image = new Image();
        image.Source = BitmapFrame.Create(fs, BitmapCreateOptions.None,
            BitmapCacheOption.OnLoad);
        imgPatch2.Source = image.Source;
    }
        
