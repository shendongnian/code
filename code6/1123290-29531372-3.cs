    public enum SubType
    {
        BaseType,
        Type1,
        Type2,
    }
    [JsonConverter(typeof(SubTypeClassConverter))]
    public class SubTypeClassBase
    {
        static readonly Dictionary<Type, SubType> typeToSubType;
        static readonly Dictionary<SubType, Type> subTypeToType;
        static SubTypeClassBase()
        {
            typeToSubType = new Dictionary<Type,SubType>()
            {
                { typeof(SubTypeClassBase), SubType.BaseType },
                { typeof(SubTypeClass1), SubType.Type1 },
                { typeof(SubTypeClass2), SubType.Type2 },
            };
            subTypeToType = typeToSubType.ToDictionary(pair => pair.Value, pair => pair.Key);
        }
        public static Type GetType(SubType subType)
        {
            return subTypeToType[subType];
        }
        [JsonConverter(typeof(StringEnumConverter))] // Serialize enums by name rather than numerical value
        public SubType Type { get { return typeToSubType[GetType()]; } }
    }
    public class SubTypeClass1 : SubTypeClassBase
    {
        public string AaaField { get; set; }
    }
    public class SubTypeClass2 : SubTypeClassBase
    {
        public string ZzzField { get; set; }
    }
    public class SubTypeClassConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SubTypeClassBase);
        }
        public override bool CanWrite { get { return false; } }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var typeToken = token["Type"];
            if (typeToken == null)
                throw new InvalidOperationException("invalid object");
            var actualType = SubTypeClassBase.GetType(typeToken.ToObject<SubType>(serializer));
            if (existingValue == null || existingValue.GetType() != actualType)
            {
                var contract = serializer.ContractResolver.ResolveContract(actualType);
                existingValue = contract.DefaultCreator();
            }
            using (var subReader = token.CreateReader())
            {
                // Using "populate" avoids infinite recursion.
                serializer.Populate(subReader, existingValue);
            }
            return existingValue;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
