    [DataContract]
    public enum TransferState : int
    {
        [EnumMember]
        OPEN = 0,
        [EnumMember]
        PENDING = 1,
        [EnumMember]
        CLOSE = 2
    }
