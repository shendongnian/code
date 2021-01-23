    public class MyEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType.IsEnum);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value;
            string strValue;
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                if (existingValue == null || Nullable.GetUnderlyingType(existingValue.GetType()) != null)
                    return null;
                strValue = "0";
            }
            else 
                strValue = value.ToString();
            int intValue;
            if (int.TryParse(strValue, out intValue))
                return Enum.ToObject(objectType, intValue);
            return Enum.Parse(objectType, strValue);
        }
    }
