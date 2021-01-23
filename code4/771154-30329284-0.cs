    public class NancyCustomRootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
    #if DEBUG
            return Directory.GetParent(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).FullName;
    #else
            return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    #endif
        }
    }
