    foreach (var dllPath in Directory.EnumerateFiles(Environment.CurrentDirectory, "*.dll"))
    {
        try
        {
            var assembly = Assembly.LoadFile(dllPath);
            var types = assembly.GetTypes();
        }
        catch (System.BadImageFormatException ex)
        {
            // this is not an assembly
        }
    }
