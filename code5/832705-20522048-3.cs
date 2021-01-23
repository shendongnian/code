    public static IEnumerable<DirectoryInfo> GetDirectories(
        DirectoryInfo directory,
        DateTime startDate,
        DateTime endDate)
    {
        return directory.GetDirectories()
            .Where(x => x.CreationTime >= startDate && x.CreationTime <= endDate);
    }
