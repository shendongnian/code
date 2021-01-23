        static void Tidy( DirectoryInfo tree )
        {
            foreach (DirectoryInfo di in tree.EnumerateDirectories())
            {
                Tidy(di);
            }
            tree.Refresh();
            if (!tree.EnumerateFileSystemInfos().Any())
            {
                tree.Delete();
            }
            return;
        }
