    [DataContract]
    public class currencyData
    {
        [DataMember(Name="response")]
        public CurrencyResponse response { get; set; }
    }
    [DataContract]
    public class CurrencyResponse
    {
        public CurrencyResponse()
        {
            this.items = new Dictionary<string,ItemPrices>();
        }
        [DataMember]
        public int success { get; set; }
        [DataMember]
        public long current_time { get; set; }
        [DataMember]
        public decimal raw_usd_value { get; set; }
        [DataMember]
        public string usd_currency { get; set; }
        [DataMember]
        public long usd_currency_index { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Dictionary<string, ItemPrices> items { get; set; }
    }
    [DataContract]
    public class ItemPrices
    {
        public ItemPrices()
        {
            this.prices = new Dictionary<long, ItemTradablePrices>();
        }
        [DataMember(EmitDefaultValue = false)]
        public Dictionary<long, ItemTradablePrices> prices { get; set; }
    }
    [DataContract]
    public class ItemTradablePrices
    {
        [DataMember(EmitDefaultValue = false)]
        public ItemCraftablePrices Tradable { get; set; }
        // Sometimes appears as "Non-Tradable", sometimes "Untradable".  Handle both
        [DataMember(EmitDefaultValue = false)]
        public ItemCraftablePrices Untradable { get; set; }
        [DataMember(Name = "Non-Tradable", EmitDefaultValue=false)]
        ItemCraftablePrices NonTradable
        {
            get
            {
                return null;
            }
            set
            {
                Untradable = value;
            }
        }
    }
    [DataContract]
    public class ItemCraftablePrices
    {
        [DataMember(EmitDefaultValue = false)]
        [JsonConverter(typeof(PrinceIndexDictionaryConverter))]
        public Dictionary<long, PriceIndex> Craftable { get; set; }
        // Sometimes appears as "Non-Craftable", sometimes "Uncraftable".  Handle both
        [DataMember(EmitDefaultValue=false)]
        [JsonConverter(typeof(PrinceIndexDictionaryConverter))]
        public Dictionary<long, PriceIndex> Uncraftable { get; set; }
        [DataMember(Name="Non-Craftable", EmitDefaultValue=false)]
        [JsonConverter(typeof(PrinceIndexDictionaryConverter))]
        Dictionary<long, PriceIndex> NonCraftable
        {
            get
            {
                return null;
            }
            set
            {
                Uncraftable = value;
            }
        }
    }
    public class PrinceIndexDictionaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Dictionary<long, PriceIndex>);
        }
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dict = existingValue as Dictionary<long, PriceIndex>;
            if (dict == null)
                dict = new Dictionary<long, PriceIndex>();
            switch (reader.TokenType)
            {
                case JsonToken.StartArray:
                    List<PriceIndex> list = new List<PriceIndex>();
                    serializer.Populate(reader, list);
                    for (int i = 0; i < list.Count; i++)
                        dict[i] = list[i];
                    break;
                case JsonToken.StartObject:
                    serializer.Populate(reader, dict);
                    break;
                default:
                    Debug.WriteLine("Unexpected token type " + reader.TokenType.ToString());
                    throw new InvalidOperationException();
            }
            return dict;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public class PriceIndex
    {
        public string currency { get; set; }
        public decimal value { get; set; }
        public decimal value_high { get; set; }
        public decimal value_raw { get; set; }
        public decimal value_high_raw { get; set; }
        public long last_update { get; set; }
        public decimal difference { get; set; }
    }
