    public static IEnumerable<SftpFile> ListDirectoryWC(this SftpClient client, string pattern, Func<SftpFile,bool> includeTest=null)
    {
        string directoryName = (pattern[0] == '/' ? "" : "/") + pattern.Substring(0, pattern.LastIndexOf('/'));
        string regexPattern = pattern.Substring(pattern.LastIndexOf('/') + 1)
                .Replace(".", "\\.")
                .Replace("*", ".*")
                .Replace("?", ".");
        Regex reg = new Regex('^' + regexPattern + '$');
        var results = client.ListDirectory(directoryName)
            .Where(e => reg.IsMatch(e.Name) && (includeTest == null || includeTest(e)));
        return results;
    }
    public static void DeleteFileWC(this SftpClient client, string pattern, Func<SftpFile,bool> includeTest=null)
    {
        foreach(var file in client.ListDirectoryWC(pattern, includeTest))
        {
            file.Delete();
        }
    }
