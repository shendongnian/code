    public PayrollPeriod
    {
        ...
        public virtual int? RecordsProcessed { get; set; }
    }
    
    public PayrollPeriodMap()
    {
        Join("PayrollProcessingProgress", join => 
        {
            join.KeyColumn("PayrollPeriodId");
            join.Optional();
            join.Map(x => x.RecordsProcessed);
        });
    }
