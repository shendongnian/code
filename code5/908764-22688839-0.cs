    static void Main(string[] args)
    {
        string yafs = "Looking for LOVE in all the wrong places...";
        string searchTerm = "love";
        Console.Write(ReplaceInsensitive(yafs, searchTerm));
        Console.Read();
    }
    private static string ReplaceInsensitive(string yafs, string searchTerm)
    {
        int start = yafs.IndexOf(searchTerm, StringComparison.InvariantCultureIgnoreCase);
        yafs = yafs.Insert(start, "<span style='background-color: #FFFF00'>");
        int end = yafs.LastIndexOf(searchTerm, StringComparison.InvariantCultureIgnoreCase);
        yafs = yafs.Insert(end + searchTerm.Length, "</span>");
        return yafs;
    }
