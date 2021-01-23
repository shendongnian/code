    [JsonConverter(typeof(StringEnumConverter))] // Add this
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
    public class GridFilter
    {
        [JsonProperty("operator")]
        //[JsonConverter(typeof(StringEnumConverter")] // Remove this
        public FilterOperator Operator { get; set; }
    }
