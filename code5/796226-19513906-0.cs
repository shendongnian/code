        public class ParametersContructorConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(Letters).IsAssignableFrom(objectType);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var jo = JObject.Load(reader);
                var contructor = objectType.GetConstructors().FirstOrDefault();
                if (contructor == null)
                {
                    return serializer.Deserialize(reader);
                }
                var parameters = contructor.GetParameters();
                var values = parameters.Select(p => jo.GetValue(p.Name, StringComparison.InvariantCultureIgnoreCase).ToObject(p.ParameterType)).ToArray();
                return contructor.Invoke(values);
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }
