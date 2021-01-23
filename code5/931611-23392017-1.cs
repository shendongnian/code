    var types = new List<Type>();
    var paths = Directory.GetFiles("directoryPath", "*.dll", SearchOption.TopDirectoryOnly);
    foreach(var path in paths)
    {
        types.AddRange(Assembly.LoadFrom(path).GetTypes());
    }
