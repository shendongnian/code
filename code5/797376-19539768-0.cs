    public string Path { get; set; }
    
    public string FileName
    {
        get { return System.IO.Path.GetFileName(this.Path); }
    }
