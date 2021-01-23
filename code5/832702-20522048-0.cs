    public static IEnumerable<DirectoryInfo> GetDirectories(
        DirectoryInfo directory,
        DateTime startDate,
        DateTime endDate)
    {
        return directory.GetDirectories()
            .Where(x => IsInRange(x.CreationTime, startDate, endDate));
    }
