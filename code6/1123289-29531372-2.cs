    [JsonConverter(typeof(SubTypeClassConverter))]
    public class SubTypeClassBase
    {
        [JsonConverter(typeof(StringEnumConverter))] // Serialize enums by name rather than numerical value
        public SubType Type { get { return typeToSubType[GetType()]; } }
    }
