    [JsonConverter(typeof(DocConverter))]
    public abstract class Doc
    {
        public string id;
    }
    
    [JsonConverter(typeof(NoConverter))] // Prevents infinite recursion when converting a class instance known to be of type DocSingle
    public class DocSingle : Doc
    {
        public long xx;
    }
    [JsonConverter(typeof(NoConverter))] // Prevents infinite recursion when converting a class instance known to be of type DocList
    public class DocList : Doc
    {
        public int[] xx;
    }
    public class DocConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }
        public override bool CanConvert(Type objectType)
        {
            return typeof(Doc).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, 
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            if (item["xx"].Type == JTokenType.Integer)
            {
                return item.ToObject<DocSingle>();
            }
            else
            {
                return item.ToObject<DocList>();
            }
        }
        public override void WriteJson(JsonWriter writer, 
            object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public class NoConverter : JsonConverter
    {
        public override bool CanRead { get { return false; } }
        public override bool CanWrite { get { return false; } }
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
