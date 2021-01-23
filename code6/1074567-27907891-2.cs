    class Program
    {
        static void Main(string[] args)
        {
            CheckAndCreateFolder("C:\\FolderCreate");
            CheckAndCreateFolder("C:\\FolderCreate2");
            CheckAndCreateFolder("C:\\FolderCreate3");
            CheckAndCreateFolder("C:\\FolderCreate4");
        }
        static void CheckAndCreateFolder(string p)
        {
            if (!Directory.Exists(p)) 
            {
                Directory.CreateDirectory(p);
            }
        }
    }
