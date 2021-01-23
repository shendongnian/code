    Stream imageStreamSource = new FileStream("filename", FileMode.Open, FileAccess.Read, FileShare.Read);
    TiffBitmapDecoder decoder = new TiffBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
    int pagecount = decoder.Frames.Count;
    if (pagecount > 1)
    {
        string fNameBase = Path.GetFileNameWithoutExtension("filename");
        string filePath = Path.GetDirectoryName("filename");
        for (int i = 0; i < pagecount; i++)
        {
            string outputName = string.Format(@"{0}\SplitImages\{1}-{2}.tif", filePath, fNameBase, i.ToString());
            FileStream stream = new FileStream(outputName, FileMode.Create, FileAccess.Write);
            TiffBitmapEncoder encoder = new TiffBitmapEncoder();
            encoder.Frames.Add(decoder.Frames[i]);
            encoder.Save(stream);
            stream.Dispose();                        
        }
        imageStreamSource.Dispose();
    }
