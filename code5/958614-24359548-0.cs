    public static string GetAssemblyDirectory()
    {
        return HostingEnvironment.IsHosted
                            ? HttpRuntime.BinDirectory
                            : Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
    }
