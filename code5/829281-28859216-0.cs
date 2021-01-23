    [DataContract(Name = "RecordState")]
    public enum CustomerRecordStateEnum
    {
        [EnumMember]
        Unchanged = 0,
        [EnumMember]
        Added = 1,
        [EnumMember]
        Modified = 2,
        [EnumMember]
        Deleted = 3
    }
