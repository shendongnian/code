    public static string ReplaceInsensitive(string yafs, string searchTerm) {
        return Regex.Replace(yafs,
            "(" + Regex.Escape(searchTerm) + ")", 
            "<span style='background-color: #FFFF00'>$1</span>",
            RegexOptions.IgnoreCase);
    }
