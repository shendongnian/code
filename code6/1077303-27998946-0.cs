    [Index("MetaPeriodDateUnq", IsUnique = true, Order = 2)]
    public DateTime Date { get; set; }
    [Index("MetaPeriodDateUnq", IsUnique = true, Order = 1)]
    public Guid PeriodId { get; set; }
    public virtual PeriodType Period { get; set; }
