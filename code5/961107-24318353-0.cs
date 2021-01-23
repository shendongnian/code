    using (var openFile1 = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
    {
        blah, blah, blah
        .
        .
        .
        openFileBytesNumber = openFile1.Length;
        byteArray = new byte[openFileBytesNumber];
        openFile1.Read(byteArray, 0, (int)(openFileBytesNumber));
        fullByteString = Convert.ToBase64String(byteArray);
    }
    
