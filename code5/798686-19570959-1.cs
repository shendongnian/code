    private static IEnumerable<DirectoryInfo> GetDirectoriesWithoutThrowing(
        DirectoryInfo dir)
    {
        try
        {
            return dir.GetDirectories();
        }
        catch (Exception)//if possible catch a more derived exception
        {
            //TODO consider logging the exception
            return Enumerable.Empty<DirectoryInfo>();
        }
    }
