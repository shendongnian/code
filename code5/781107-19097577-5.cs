    public IEnumerable<Build> GetBuildsInRange(string beginVersion, string lastVersion)
    {
        var startVersion = start.ParseToVersion();
        var endVersion = end.ParseToVersion();
        if (startVersion == null || endVersion == null) return IEnumerable.Empty<Build>();
        return YourDbContext.Builds.Where(b =>
            b.Version.ParseToVersion() >= startVersion
         && b.Version.ParseToVersion() <= endVersion);
    }
