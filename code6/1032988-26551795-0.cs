    public static int GetNextNumber(string directoryPath)
    {
        var dirs = Directory.GetDirectories(directoryPath);
        return dirs.Length + 1;
    }
