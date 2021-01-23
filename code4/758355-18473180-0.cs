    public long TickCount { get; set; }
    [NotMapped]
    public TimeSpan Span { 
        get { 
            return new TimeSpan(TickCount); 
        } 
        set { 
            TickCount = value.Ticks; 
        } 
    }
