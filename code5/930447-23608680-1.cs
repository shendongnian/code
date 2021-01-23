    var bytes = Encoding.UTF8.GetBytes(html.ToString());
    using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
    {
        using (IsolatedStorageFileStream output = iso.CreateFile("Testfile.html"))
        {
            output.Write(bytes, 0, bytes.Length);
        }
    }
