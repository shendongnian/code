    [EnumDataType(typeof(ValidValues), ErrorMessage = "Valid values are 1,2,4")]
    public int ReqValue { get; set; }
    public enum ValidValues
    {
        First = 1,
        Second = 2,
        Fourth = 4
    }
