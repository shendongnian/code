    public Nullable<bool> Active
    {
        get;
        set;
    }
    public string ISActive
    {
        get
        {
            return (bool)this.Active ? "Yes" : "NO";
        }
    }
