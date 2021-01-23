    // Do this when your add-in starts
    var addinAssembly = Assembly.GetExecutingAssembly();
    AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
    {
        var missing = new AssemblyName(e.Name);
        // Sometimes the WPF assembly resolver cannot even find the executing assembly...
        if (missing.FullName == addinAssembly.FullName)
            return addinAssembly;
        var addinFolder = Path.GetDirectoryName(addinAssembly.Location);
        var missingPath = Path.Combine(addinFolder, missing.Name + ".dll");
        // If we find the DLL in the add-in folder, load and return it.
        if (File.Exists(missingPath))
            return Assembly.LoadFrom(missingPath);
        // nothing found
        return null;
    };
    
