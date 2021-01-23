    [Key, ForeignKey("SalesHeader")]
    [Column("Document Type", Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Document_Type { get; set; }
    [Key, ForeignKey("SalesHeader")]
    [Column("Document No_", Order = 1)]
    [StringLength(20)]
    public string Document_No_ { get; set; }
