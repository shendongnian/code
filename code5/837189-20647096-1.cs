    /// <summary>
    /// Loads the machine wide settings.
    /// </summary>
    /// <remarks>
    /// For example, if <paramref name="paths"/> is {"IDE", "Version", "SKU" }, then
    /// the files loaded are (in the order that they are loaded):
    ///     %programdata%\NuGet\Config\IDE\Version\SKU\*.config
    ///     %programdata%\NuGet\Config\IDE\Version\*.config
    ///     %programdata%\NuGet\Config\IDE\*.config
    ///     %programdata%\NuGet\Config\*.config
    /// </remarks>
    /// <param name="fileSystem">The file system in which the settings files are read.</param>
    /// <param name="paths">The additional paths under which to look for settings files.</param>
    /// <returns>The list of settings read.</returns>
    public static IEnumerable<Settings> LoadMachineWideSettings(
        IFileSystem fileSystem,
        params string[] paths)
    {
        List<Settings> settingFiles = new List<Settings>();
        string basePath = @"NuGet\Config";
        string combinedPath = Path.Combine(paths);
        while (true)
        {   
            string directory = Path.Combine(basePath, combinedPath);
            // load setting files in directory
            foreach (var file in fileSystem.GetFiles(directory, "*.config"))
            ...
