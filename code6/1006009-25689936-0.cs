    public static void WriteAllTextSafe(string path, string contents)
    {
        // DISABLED: User temp folder might be on different drive
        // var tempPath = Path.GetTempFileName();
        // use the same folder so that they are always on the same drive!
        var tempPath = Path.Combine(Path.GetDirectoryName(path), Guid.NewGuid().ToString());
        ....
    }
