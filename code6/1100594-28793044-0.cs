    public long aFK { get; set; }
    public long bFK { get; set; }
    [InverseProperty("aFK")]
    public virtual User a { get; set; }
    [InverseProperty("bFK")]
    public virtual User b { get; set; }
