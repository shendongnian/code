    public App()
    {
        var a = Assembly.GetExecutingAssembly();
        var attributes = a.GetCustomAttributes<AssemblyAssociatedContentFileAttribute>();
        foreach (var attr in attributes)
        {
            var path = attr.RelativeContentFilePath;
            //Verify if a given path exists
            ...
        }
    }
