    public static string GetFileName(string regValue)
    {
        int extensionIndex = regValue.IndexOf(".exe", StringComparison.OrdinalIgnoreCase);
        if (extensionIndex < 0) return string.Empty;
        return Path.GetFileName(regValue.Replace("\"", "")
            .Substring(0, extensionIndex + 4));
    }
