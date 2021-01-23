    private void RemoveEmptyFolders(string path)
    {
        foreach (string subFolder in Directory.GetDirectories(path))
            removeEmptyFolders(subFolder);
    }
    private bool removeEmptyFolders(string path)
    {
        bool isEmpty = Directory.GetDirectories(path).Aggregate(true, (current, subFolder) => current & removeEmptyFolders(subFolder))
            && Directory.GetFiles(path).Length == 0;
        if (isEmpty)
            Directory.Delete(path);
        return isEmpty;
    }
