    public List<string> getFiles(string path, string searchPattern, List<string> list)
    {
        try
        {
            foreach (string folder in Directory.GetDirectories(path))
                getFiles(folder, searchPattern, list);
            list.AddRange(Directory.GetFiles(path, searchPattern));
        }
        catch (UnauthorizedAccessException)
        {
            //Do not have access to the file.
        }
        return list;
    }
