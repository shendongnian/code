    public virtual District District  { get; set; }
    public virtual District GetDistrictOrDefault()
    {
        return District ?? this.Zone;
    }
