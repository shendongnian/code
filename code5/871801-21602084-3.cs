    public void UseAction(Action<string> getFile)
    {
        getFile.Invoke(@"C:\");
    }
    foo.UseAction(getFile);
