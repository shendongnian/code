    public enum HexRequestType
    {
        Unknown,
        Login,
        Logout,
        SaveDeck,
        DraftPack,
        DraftCardPicked,
        GameStarted,
        GameEnded,
        Collection,
    }
    [JsonConverter(typeof(HexRequestConverter))]
    public class HexRequest
    {
        [JsonIgnore]
        public HexRequestType RequestType
        {
            get
            {
                if (string.IsNullOrEmpty(MessageName))
                    return HexRequestType.Unknown;
                if (MessageName.Equals("DaraftCardPicked", StringComparison.OrdinalIgnoreCase))
                    return HexRequestType.DraftCardPicked;
                try
                {
                    return (HexRequestType)Enum.Parse(typeof(HexRequestType), MessageName, true);
                }
                catch (Exception)
                {
                    Debug.WriteLine("Unknown request " + MessageName);
                    return HexRequestType.Unknown;
                }
            }
        }
        public string MessageName { get; set; }
        public string UserName { get; set; }
        public JArray AdditionalData { get; set; }
    }
    public class HexRequestConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(HexRequest);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var array = JToken.Load(reader) as JArray;
            if (array == null)
                return existingValue;
            var request = existingValue as HexRequest ?? new HexRequest();
            request.MessageName = (array.Count > 0 ? (string)array[0] : null);
            request.UserName = (array.Count > 1 ? (string)array[1] : null);
            request.AdditionalData = (JArray)(array.Count > 2 ? array[2] : null) ?? new JArray();
            if (array.Count > 3)
            {
                Debug.WriteLine("array too large");
                throw new InvalidOperationException();
            }
            return request;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var request = (HexRequest)value;
            var list = new List<object> { request.MessageName, request.UserName, request.AdditionalData };
            serializer.Serialize(writer, list);
        }
    }
