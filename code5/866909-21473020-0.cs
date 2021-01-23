    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    public class SizeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(System.Drawing.Size));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            System.Drawing.Size size = (System.Drawing.Size)value;
            JObject jo = new JObject();
            jo.Add("width", size.Width);
            jo.Add("height", size.Height);
            jo.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            return new System.Drawing.Size((int)jo["width"], (int)jo["height"]);
        }
    }
