    if (!string.IsNullOrEmpty(comment)) {
       fs.WriteByte(0x21);
       fs.WriteByte(0xfe);
       var bytes = Encoding.ASCII.GetBytes(comment);
       fs.WriteByte((byte)bytes.Length);
       fs.Write(bytes, 0, bytes.Length);
       fs.WriteByte(0);
    }
    // Rest of code
    //...
