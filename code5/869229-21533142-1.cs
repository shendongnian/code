    using (var isfs = new IsolatedStorageFileStream(newFileName, FileMode.OpenOrCreate, storage))
    {
        isfs.Seek(0, SeekOrigin.End); //THIS LINE DID SOLVE MY PROBLEM
        while ((byteCount = f.Read(bytes, 0, bytes.Length)) > 0)
        {
            isfs.Write(bytes, 0, byteCount);
            isfs.Flush();
        }
    }
