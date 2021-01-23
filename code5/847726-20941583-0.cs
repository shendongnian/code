    public static void InitializeFiles()
    {
        using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
        {
            if (!isf.FileExists("settings.xml"))
            {
                isf.CreateFile("settings.xml").Dispose();
                XDocument xml;
                using (Stream stream = File.Open("Content/settings.xml", FileMode.Open, FileAccess.Read))
                {
                    xml = XDocument.Load(stream);
                }
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("settings.xml", FileMode.Create, isf))
                {
                    xml.Save(stream);
                }
            }
        }
    }
