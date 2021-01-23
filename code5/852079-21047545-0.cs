    public static List<String> GetSubFoldersMatching(String attachmentDirectory, String pattern)
    {
        Regex regex = new Regex(pattern);
        return GetSubFoldersMatching(attachmentDirectory, regex);
    }
    
    public static List<String> GetSubFoldersMatching(String attachmentDirectory, Regex regex)
    {
        List<String> matching = new List<String>();
        foreach (String directoryName in Directory.GetDirectories(attachmentDirectory))
        {
            Match match = regex.Match(directoryName);
            if (match.Success)
            {
                matching.Add(directoryName);
            }
            else
            {
                matching.AddRange(GetSubFoldersMatching(directoryName, regex));
            }
        }
        return matching;
    }
