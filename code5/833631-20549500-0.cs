    private IEnumerable<Assembly> LoadAssemblies(string folder)
    {
        IEnumerable<string> dlls =
            from file in new DirectoryInfo(folder).GetFiles()
            where file.Extension == ".dll"
            select file.FullName;
        IList<Assembly> assemblies = new List<Assembly>();
        foreach (string dll in dlls)
        {
            try
            {
                assemblies.Add(Assembly.LoadFile(dll));
            }
            catch
            {
            }
        }
        return assemblies;
    }
