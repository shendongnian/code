    using System;
    using System.Drawing;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    public class SizeJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Size));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Size size = (Size)value;
            JObject jo = new JObject();
            jo.Add("width", size.Width);
            jo.Add("height", size.Height);
            jo.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            return new Size((int)jo["width"], (int)jo["height"]);
        }
    }
