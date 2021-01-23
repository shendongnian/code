    // Try this
    public int GetHashCode(string obj)
    {
        return Path.GetFileName(x).GetHashCode();
    }
    // And this
    public int GetHashCode(string obj)
    {
        return new FileInfo(x).Length.GetHashCode();
    }
