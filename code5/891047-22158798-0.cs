    private DateTime? dateCreated;
    public DateTime DateCreated
    {
        get { return dateCreated ?? DateTime.Now; }
        set { dateCreated = value; }
    }
