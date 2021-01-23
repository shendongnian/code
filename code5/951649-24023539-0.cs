    var files = new System.IO.DirectoryInfo("").GetFiles("*.cs");
    foreach(System.IO.FileInfo file in files)
    {
        var assem = Assembly.LoadFrom(file.FullName);
        object instance = assem.CreateInstance(file.Name);
        if(instance is BaseScript)
        {
            //Do processing on (BaseScript)instance
        }
    }
