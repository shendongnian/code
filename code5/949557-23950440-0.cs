    \\Create file and save data
      using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("file.txt", FileMode.Create, IsolatedStorageFile.GetUserStoreForApplication()))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.WriteLine(1);
                        writer.WriteLine("Hello");
                    }
                }
    
    \\To read from the file
    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("file.txt", FileMode.Open, IsolatedStorageFile.GetUserStoreForApplication()))
    {
        using (StreamReader reader = new StreamReader(stream))
        {
            int number = Convert.ToInt32(reader.ReadLine());
            string text = reader.ReadLine();
        }
    }
