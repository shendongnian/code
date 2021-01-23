        public DBStoreDocument(string filePath)
        {
            this.Load(filePath);
        }
    string[] filePaths = Directory.GetFiles(@"" + directory, "*.gpg", SearchOption.AllDirectories);
    foreach (string path in filePaths)
    {
         Documenttest doc = new Documenttest(path);
    }
