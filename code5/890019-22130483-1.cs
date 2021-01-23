    public bool IsEdited { get; set; }
    public string Term 
    {
        get { return term; }
        set { term = value; IsEdited = true; } // Do for each property
    }
