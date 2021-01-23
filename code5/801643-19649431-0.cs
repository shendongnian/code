    DataContract(Name = "JobStatus")]
    public enum JobStatus
    {
        [EnumMember]
        New, 
        [EnumMember]
        Submitted,
        [EnumMember]
        Approved,
        [EnumMember]
        Returned,
        [EnumMember]
        OnHold,
        [EnumMember]
        Cancelled,
    }
