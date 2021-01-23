      using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
    {
        using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream(filePath, FileMode.Create, isf))
        {
            fileStream.Write(ms.ToArray(), 0, (ms .Length);
            fileStream.Close();
        }
    }
