    [DataMember, NotMapped]
    public string DateUtcAsString {
        get { return DateUtcAsDateTime.ToString("o"); }
        set { DateUtcAsDateTime = DateTime.Parse(value, "o", null, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal); }
    }
