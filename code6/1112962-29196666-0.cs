    [DataContract(Name = "test-object")]
    public class TestObject
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [IgnoreDataMember]
        public bool BoolValue { get; set; }
        [IgnoreDataMember]
        public string StringValue { get; set; }
        bool ShouldSerializeStringValue()
        {
            return !String.IsNullOrWhiteSpace(StringValue);
        }
        // If string-value is not null or whitespace do not serialize bool-value
        [DataMember(Name = "bool-value", EmitDefaultValue=false)]
        bool? SerializedBoolValue {
            get
            {
                if (!ShouldSerializeStringValue())
                    return BoolValue;
                return null;
            }
            set
            {
                BoolValue = (value ?? false); // Or don't set it at all if value is null - your choice.
            }
        }
        // If string-value is null or whitespace do not serialize it
        [DataMember(Name = "string-value", EmitDefaultValue=false)]
        string SerializedStringValue {
            get
            {
                if (ShouldSerializeStringValue())
                    return StringValue;
                return null;
            }
            set
            {
                StringValue = value;
            }
        }
    }
