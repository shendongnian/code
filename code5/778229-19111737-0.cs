    public PayrollProcessingProgress
    {
        public virtual PayrollPeriod Period { get; set; }
        public virtual int RecordsProcessed { get; set; }
    }
    
    public PayrollProcessingProgressMap()
    {
        CompositeId().KeyReference(x => x.Period, "PayrollPeriodId");
    
        Map(x => x.RecordsProcessed);
    }
