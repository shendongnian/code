    public string UseAction(Action<string> getFile)
    {
        return getFile.Invoke();
    }
    string path = foo.UseAction();
