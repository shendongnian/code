    public IndexKeysBuilder Text(string name)
    {
        _document.Add(name, "text");
        return this;
    }
