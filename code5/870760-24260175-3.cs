    [Index("IX_UniqueKeyString", IsUnique = true, Order = 1)]
    [MaxLength(50)]
    public string UniqueKeyStringPart1 { get; set; }
    [Index("IX_UniqueKeyString", IsUnique = true, Order = 2)]
    [MaxLength(50)]
    public string UniqueKeyStringPart2 { get; set; }
