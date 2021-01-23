    using Newtonsoft.Json;
    namespace WebCrawler.Models {
        [JsonObject(MemberSerialization.OptIn)]
        public class LinkDataViewModel : JsonConverter
        {
            [JsonProperty]
            public string Title { get; set; }
            .....
            [JsonProperty]
            public string CustomerID { get; set; }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue,            JsonSerializer serializer)
            {
               throw new NotImplementedException();
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
               if (value == null)
               {
                 serializer.Serialize(writer, null);
                 return;
                }      
                var properties = value.GetType().GetProperties();
                writer.WriteStartObject();
                //your custom property
                writer.WritePropertyName("PostPropertyRequest");
                writer.WriteStartObject();
                foreach (var property in properties)
                {
                  // write property name
                  writer.WritePropertyName(property.Name);
                  serializer.Serialize(writer, property.GetValue(value, null));
                }
                writer.WriteEndObject();
                writer.WriteEndObject();
            }
        }
    }
