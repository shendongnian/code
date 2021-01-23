    public static StreamContainer CreateForFile(string path)
    {
        return new StreamContainer(path, new FileStream(path, FileMode.Open, FileAccess.Read));
    }
    
    public static StreamContainer CreateWithoutFile(string name)
    {
        return new StreamContainer(name, new MemoryStream());
    }
