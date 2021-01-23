    public static bool IsFileAvailable(string filePath)
    {
        if (!File.Exists(filePath))
            return false;
        var attributes = File.GetAttributes(filePath);
        Debug.WriteLine(attributes);
        // Available online-only: Hidden, System, Archive, SparseFile, ReparsePoint, Offline
        // Available offline: Archive
        return !attributes.HasFlag(FileAttributes.Offline);
    }
