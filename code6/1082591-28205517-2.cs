    [DataContract]
    public enum FilterOperator
    {
        [EnumMember(Value = "eq")]
        Equals,
        [EnumMember(Value = "gt")]
        GreaterThan,
        [EnumMember(Value = "lt")]
        LessThan,
        [EnumMember(Value = "in")]
        In,
        [EnumMember(Value = "like")]
        Like
    }
