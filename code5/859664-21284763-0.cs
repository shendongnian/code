    string str = "these are characters";
    byte[] bytes = new byte[str.Length];
    
    for (var i = 0; i < str.Length; i++)
    {
        bytes[i] = Convert.ToByte(str[i]);
    }
    
    // create the file here ... then ...
    await Windows.Storage.FileIO.WriteBytesAsync(file, bytes);
