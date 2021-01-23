    private string path;
    
    public string FileName { get; set; }
    public string Path 
    {
        get 
        { 
            return path; }
        set 
        { 
            path = value;
            FileName = Path.GetFileName(value);
        } 
    }
