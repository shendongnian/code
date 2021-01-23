    var hType = JsonConvert.DeserializeObject<HType>(
                                @"{""types"" : [ ""hotel"", ""spa"" ]}",
                                new MyEnumConverter());
---
    public class HType
    {
        public List<eType> types { set; get; }
    }
    public enum eType
    {
        [Description("hotel")]
        kHotel,
        [Description("spa")]
        kSpa
    }
    public class MyEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(eType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var eTypeVal =  typeof(eType).GetMembers()
                            .Where(x => x.GetCustomAttributes(typeof(DescriptionAttribute)).Any())
                            .FirstOrDefault(x => ((DescriptionAttribute)x.GetCustomAttribute(typeof(DescriptionAttribute))).Description == (string)reader.Value);
            if (eTypeVal == null) return Enum.Parse(typeof(eType), (string)reader.Value);
            return Enum.Parse(typeof(eType), eTypeVal.Name);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
