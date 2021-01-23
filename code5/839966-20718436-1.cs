    public string HashTags { get; set; }
    public string IList<string> HashTagsFormated 
    {
        get {
           return { HashTags.Split(',').ToList(); 
        }
    }
