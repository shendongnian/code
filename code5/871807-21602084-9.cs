    public string UseFunc(Func<string[], string> getFile, string[] validExtensions)
    {
        return getFile.Invoke(validExtensions);
    }
    string path = foo.UseFunc(getFile);
