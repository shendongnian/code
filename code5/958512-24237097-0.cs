    using(isoVideoFile = new IsolatedStorageFileStream(isoVideoFileName,
                       FileMode.OpenOrCreate, FileAccess.ReadWrite,
                       IsolatedStorageFile.GetUserStoreForApplication()))
    {
        using(MemoryStream stream = new MemoryStream())
        {
            isoVideoFile.Write(stream.GetBuffer(), 0, (int)stream.Position);
        }
        byte[] binaryData = new Byte[isoVideoFile.Length];
        long bytesRead = isoVideoFile.Read(binaryData, 0, (int)isoVideoFile.Length);
        string videofile = Convert.ToBase64String(binaryData, 0, binaryData.Length);
    }
