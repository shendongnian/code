    public class ItemsHolderJsonConverter : CustomCreationConverter<ItemsHolder>
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ItemsHolder).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader,
                                       Type objectType,
                                       object existingValue,
                                       JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            ItemsHolder holder = base.ReadJson(CreateReaderFromToken(reader,jObject), objectType, existingValue, serializer) as ItemsHolder;
            var jItems = jObject[nameof(ItemsHolder.Items)] as JArray ?? new JArray();
            foreach (var jItem in jItems)
            {
                var childReader = CreateReaderFromToken(reader, jItem);
                var item = serializer.Deserialize<Item>(childReader);
                holder.AddItem(item);
            }
            return holder;
        }
        public override ItemsHolder Create(Type objectType)
        {
            return new ItemsHolder();
        }
        public static JsonReader CreateReaderFromToken(JsonReader reader, JToken token)
        {
            JsonReader jObjectReader = token.CreateReader();
            jObjectReader.Culture = reader.Culture;
            jObjectReader.DateFormatString = reader.DateFormatString;
            jObjectReader.DateParseHandling = reader.DateParseHandling;
            jObjectReader.DateTimeZoneHandling = reader.DateTimeZoneHandling;
            jObjectReader.FloatParseHandling = reader.FloatParseHandling;
            jObjectReader.MaxDepth = reader.MaxDepth;
            jObjectReader.SupportMultipleContent = reader.SupportMultipleContent;
            return jObjectReader;
        }
    }
