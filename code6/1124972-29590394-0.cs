    [DataMember(Name = "someEpochDateTime")]
    private long someEpochDateTime;
    
    public DateTime test
    {
        get { return DateTimeConverter.FromUnixTime(someEpochDateTime); }
    }
