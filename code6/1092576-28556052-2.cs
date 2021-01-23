    public File() { }
    public File(File file) : this()
    {
        this.Filename = file.Filename;
        this.FileStream = file.FileStream;
    }
    public Document() { }
    public Document(Document document) : this()
    {
        this.Type = document.Type;
        this.File = new File(document.File);
    }
