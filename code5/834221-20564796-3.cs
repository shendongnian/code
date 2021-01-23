    byte[] checksum = new byte[40];
    //...
    FileStream oldFileStream = new FileStream(oldFile, FileMode.Open, FileAccess.Read);
    FileStream newFileStream = new FileStream(newFile, FileMode.Create, FileAccess.Write);
    using(oldFileStream)
    using(newFileStream)
    {
        newFileStream.Write(checksum, 0, checksum.Length);
        oldFileStream.CopyTo(newFileStream);
    }
    File.Copy(newFile, oldFile, overwrite : true);
