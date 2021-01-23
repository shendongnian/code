    private IEnumerable<FileInfo> GetNewestFilePerDirectory(
        string root,
        string pattern = "*",
        SearchOption searchoption = SearchOption.TopDirectoryOnly
    )
    {
        return new DirectoryInfo(root)
            .EnumerateFiles(pattern, searchoption)
            .GroupBy(g => g.Directory.FullName)
            .Select(s => s.OrderBy(f => f.Name)
                .First(f => f.CreationTimeUtc == s.Max(m => m.CreationTimeUtc))
            );
    }
