        static void Main(string[] args)
        {
                List<string> dirs = new List<string>();
                addDirectoryToList(@"C:\exampledir\", dirs);
        }
        void addDirectoryToList(string dir, List<string> list)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            foreach (DirectoryInfo subdir in dirInfo.GetDirectories())
            {
                addDirectoryToList(subdir.FullName, list);
            }
        }
