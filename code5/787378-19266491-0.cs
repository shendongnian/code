    public List<string> getFiles(string path, string searchPattern, List<string> list)
    {
        try
        {
            list.AddRange(Directory.GetFiles(path, searchPattern));
            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
                getFiles(folder, searchPattern, list);
        }
        catch (UnauthorizedAccessException)
        {
        }
        return list;
    }
