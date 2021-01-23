    public static bool ContainsSubPath(this string pathToFile, string subPath)
    {
        pathToFile = Path.GetDirectoryName(pathToFile) + "\\";
        string searchPath = Path.GetDirectoryName(subPath) + "\\";
        bool containsIt = pathToFile.IndexOf(searchPath, StringComparison.OrdinalIgnoreCase) > -1;
        return containsIt;
    }
