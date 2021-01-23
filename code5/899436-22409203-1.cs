    private static string programVersion()
    {
        var assembly = Assembly.GetEntryAssembly(); // Version number of the calling exe, not this assembly!
        if (assembly != null)
            return Assembly.GetEntryAssembly().GetName().Version.ToString();
        else // Only happens if being called via reflection from, say, Visual Studio's Form Designer.
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
