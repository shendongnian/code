    // Mapped with NHibernate
    protected virtual District District  { get; set; }
    
    public virtual District DistrictOrDefault // You might find a better naming... 
    {
        get 
        {
            return District ?? this.Zone; 
        } 
        set
        {
            District = value;
        }
    }
