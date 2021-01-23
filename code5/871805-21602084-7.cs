    public string UseFunc(Func<string> getFile)
    {
        return getFile.Invoke();
    }
    string path = foo.UseFunc(getFile);
