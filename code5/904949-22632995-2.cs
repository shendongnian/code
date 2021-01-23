    private void RemoveEmptyFolders(string path)
    {
        foreach (string subFolder in Directory.GetDirectories(path))
            RemoveEmptySubFolders(subFolder);
    }
    private bool RemoveEmptySubFolders(string path)
    {
        bool isEmpty = Directory.GetDirectories(path).Aggregate(true, (current, subFolder) => current & RemoveEmptySubFolders(subFolder))
            && Directory.GetFiles(path).Length == 0;
        if (isEmpty)
            Directory.Delete(path);
        return isEmpty;
    }
