    public virtual District District  { get; set; }
    public virtual District GetDistrictOrDefault()
    {
        return return District ?? this.Zone;
    }
