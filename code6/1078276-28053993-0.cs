    private void appendToCatalog(DirectoryTreeNode node)
    {
        DirectoryInfo info = node.Info;
        FileInfo[] dlls = info.GetFiles("*.dll");
        foreach (FileInfo fileInfo in dlls)
        {
            try
            {
                var ac = new AssemblyCatalog(Assembly.LoadFile(fileInfo.FullName));
                ac.Parts.ToArray(); // throws exception if DLL is bad
                catalog.Catalogs.Add(ac);
            }
            catch
            {
                // some error handling of your choice
            }
        }
    }
