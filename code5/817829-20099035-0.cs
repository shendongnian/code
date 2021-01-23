    [Key, ForeignKey("Keyword")]
    [Column("Keyword_Id", Order = 0)]
    public int Keyword_Id { get; set; }
    [Key, ForeignKey("Ad")]
    [Column("Ad_Id", Order = 1)]
    public int Ad_Id { get; set; }
    [Key, ForeignKey("Category")]
    [Column("Category_Id", Order = 2)]
    public int Category_Id { get; set; }
    public virtual Keyword Keyword { get; set; }
    
    public virtual Ad Ad { get; set; }
    
    public virtual Category Category { get; set; }
