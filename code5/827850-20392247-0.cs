    protected virtual byte[] Timestamp { get; set; }
    public virtual string Version
    {
        get { return Timestamp.IsEmpty() ? null : Convert.ToBase64String(Timestamp); }
        set { Timestamp = value.IsEmpty() ? null : Convert.FromBase64String(value); }
    }
