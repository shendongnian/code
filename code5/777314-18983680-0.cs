    private async Task<string> GetSkyDriveFolderID(string folderName)
    {
        client = App.LiveClient;
        LiveOperationResult operationResult = await client.GetAsync("me/skydrive/files?filter=folders");
        var iEnum = operationResult.Result.Values.GetEnumerator();
        iEnum.MoveNext();
        var folders = iEnum.Current as IEnumerable;
        foreach (dynamic v in folders)
        {
            if (v.name == folderName)
            {
                return v.id as string;
            }
        }
        return null;
    }
