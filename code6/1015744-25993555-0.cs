    public long RegisterId { get; set; }
    
    public long Value { get; set; }
    
    public virtual CountLog CountLog { get; set; }
    
    [ForeignKey("RegisterId ")]
    public virtual Register Register { get; set; }
