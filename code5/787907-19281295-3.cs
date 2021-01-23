    [NotMapped]
    public DateTimeOffset BarDTO
    {
        get { return Bar; }
        set { Bar = value.UtcDateTime; }
    }
