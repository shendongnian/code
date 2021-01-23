    public List<FolderObject> GetChildren(string repositoryId, string folderId)
    {
        List<FolderObject> items=null;
        QueryOperations query = new QueryOperations(GraphConnection);
        var queryResult = query.GetChild(folderId);
        
        Stack<FolderObject> folders = new Stack<FolderObject>(queryResult);
        foreach (FolderObject child in queryResult)
            folders.Push(child);
        while (folders.Count > 0)
        {
            FolderObject currentFolder = folders.Pop();
            var childId = currentFolder.ObjectId;
            items.Add(currentFolder);
            var nextChildren = GetChildren(repositoryId, childId);
            foreach (FolderObject child in nextChildren)
                folders.Push(child);
        }
        return items;
    }
