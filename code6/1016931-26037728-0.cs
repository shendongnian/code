    public static List<string> GetRecords(string path)
    {
        List<string> records;
        try
        {
            records = Directory.GetFiles(path)
                .Select(
                    o => string.Format("[{0}][{1}][{2}]", o, File.GetCreationTime(o), File.GetLastWriteTime(o)))
                .ToList();
            foreach (var directory in Directory.GetDirectories(path))
            {
                records.AddRange(GetRecords(directory));
            }
            return records;
        }
        catch (UnauthorizedAccessException)
        {
            return new List<string> {string.Format("[{0}][Unauthorized Access][]", path)};
        }
        catch (DirectoryNotFoundException)
        {
            return new List<string> { string.Format("[{0}][No path available][]", path) };
        }
    }
