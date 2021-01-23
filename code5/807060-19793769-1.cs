    Stream ImageStream = (MyImageControl.Source as BitmapImage).GetStream();
    IsolatedStorageFile IsoStore = IsolatedStorageFile.GetUserStoreForApplication();
    using (IsolatedStorageFileStream storageStream = IsoStore.CreateFile("TestImage.bmp"))                             
       ImageStream.CopyTo(storageStream);
   
    public static Stream GetStream(this BitmapImage image)
    {
        MemoryStream stream = new MemoryStream();              
        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(image));
        encoder.Save(stream);
        return stream;
    }
