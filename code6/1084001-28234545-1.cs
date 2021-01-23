    private static Task _alreadyDone = Task.FromResult(false);
    public override Task SaveFileAsync(XDocument xDocument)
    {
        string path = GetFilePath();
        xDocument.Save(path);
        return _alreadyDone;
    }
