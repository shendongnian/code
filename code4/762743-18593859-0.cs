    foreach (var file in Directory.GetFiles(path))
    {
        var a = Assembly.LoadFrom(file);
        foreach (var t in a.GetTypes())
        {
            foreach (var m in t.GetMethods())
            {
                // analyze the signature and see if it matches here
            }
        }
    }
