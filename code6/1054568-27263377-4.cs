    public static string GetFileName(string input)
    {
        int extensionIndex = input.IndexOf(".exe", StringComparison.OrdinalIgnoreCase);
        if (extensionIndex < 0) return string.Empty;
        return Path.GetFileName(input.Replace("\"", "").Substring(0, extensionIndex + 4));
    }
    // Or, if you want to get the full path:
    public static string GetFilePath(string input)
    {
        int extensionIndex = input.IndexOf(".exe", StringComparison.OrdinalIgnoreCase);
        if (extensionIndex < 0) return string.Empty;
        return input.Replace("\"", "").Substring(0, extensionIndex + 4);
    }
