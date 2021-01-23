    [Column("Status")]
    public int StatusInt { get; set; }
    [NotMapped]
    public StatusType Status
    {
        get { return (StatusType)StatusInt; }
        set { StatusInt = (int)value; }
    }
