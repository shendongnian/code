        void addDirectoryToList(string dir, List<string> list)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            list.Add(dir);
            foreach (DirectoryInfo subdir in dirInfo.GetDirectories("*", SearchOption.AllDirectories))
            {
                list.Add(subdir.FullName);
            }
        }
