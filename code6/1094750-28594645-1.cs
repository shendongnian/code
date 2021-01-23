    public void DownloadImage()
    {
        WebServiceWrapper wr = new WebServiceWrapper();
    
        using (var responseStream = wr.SendRequest("http://example.com/someimage.jpg"))
        using (BinaryReader reader = new BinaryReader(responseStream))
        {
            Byte[] lnByte = reader.ReadBytes(1 * 1024 * 1024 * 10);
            using (FileStream lxFS = new FileStream("34891.jpg", FileMode.Create))
            {
                lxFS.Write(lnByte, 0, lnByte.Length);
            }
        }
    }
