    [JsonConverter(typeof(DocConverter))]
    public sealed class Doc
    {
        public string id;
        public long[] xx;
    }
    public class DocConverter : JsonConverter
    {
        public override bool CanWrite { get { return true; } }
        public override bool CanConvert(Type objectType)
        {
            return typeof(Doc).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            var doc = new Doc();
            JToken id = item["id"];
            if (id != null)
                doc.id = id.ToString();
            JToken xx = item["xx"];
            if (xx != null)
            {
                if (xx.Type == JTokenType.Integer)
                {
                    var val = (long)xx;
                    doc.xx = new long[] { val };
                }
                else if (xx.Type == JTokenType.Array)
                {
                    var val = xx.ToObject<long[]>();
                    doc.xx = val;
                }
                else
                {
                    Debug.WriteLine("Unknown type of JToken for \"xx\": " + xx.ToString());
                }
            }
            return doc;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var doc = (Doc)value;
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteValue(doc.id);
            var xx = doc.xx;
            if (xx != null)
            {
                writer.WritePropertyName("xx");
                if (xx.Length == 1)
                {
                    writer.WriteValue(xx[0]);
                }
                else
                {
                    writer.WriteStartArray();
                    foreach (var x in xx)
                    {
                        writer.WriteValue(x);
                    }
                    writer.WriteEndArray();
                }
            }
            writer.WriteEndObject();
        }
    }
