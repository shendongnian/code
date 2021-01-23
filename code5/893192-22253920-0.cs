    public DateTime? InDate { get; set }
    public bool ShouldSerializeInDate()
    {
        return InDate.HasValue;
    }
