    // THUMB FILESIZE
    byteToRead = new byte[sizeof(Int32)];
    fs.Read(byteToRead, 0, byteToRead.Length);
    int thumbSize = BitConverter.ToInt32(byteToRead, 0);
    
    // GET RAW DATA
    jpegData = new byte[thumbSize];
    fs.Read(jpegData, 0, thumbSize);
    // CREATE IMAGE OBJECT
    ms = new MemoryStream(jpegData);
    this.thumbnail = new WriteableBitmap(thumbW, thumbH);
    this.thumbnail.LoadJpeg(ms);
