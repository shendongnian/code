    public static BitmapImage GetPPTXThumbnail(string filePath)
    {
        using (ZipFile zip = ZipFile.Read(filePath))
        {
            ZipEntry e = zip["docProps/thumbnail.jpeg"];
            BitmapImage bImg = new BitmapImage();
            MemoryStream memoryStream = new MemoryStream();
            bImg.BeginInit();
            e.Extract(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            bImg.StreamSource = memoryStream;
            bImg.EndInit();
            return bImg;
        }
    }
