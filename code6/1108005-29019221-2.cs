    private void saveGameToIsolatedStorage(string message)
    {
      using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
        {
         using (IsolatedStorageFileStream rawStream = isf.CreateFile("MyFile.store"))
        {
          StreamWriter writer = new StreamWriter(rawStream);
          writer.WriteLine(message); // save the message
          writer.Close();
        }
      }
    }
