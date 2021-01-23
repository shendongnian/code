        public class DateOnlyConverter : JsonConverter
       {
          public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        { 
            if (value is DateOnly)
            {
                writer.WriteValue(((DateOnly) value).Date.ToString("yyyy-MM-dd")); 
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value = reader.ReadAsString();
            try
            {
                return DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture); 
            }
            catch (FormatException)
            {
                return null; 
            }
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (DateOnly); 
        }
    }
