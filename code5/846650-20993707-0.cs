    public class StringEnumConverterEx : StringEnumConverter
        {
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                // the message in the response, once an serialization exception is thrown, after the version 4.5.1 of Newtonsoft.JSON library,
                // has changed. As we do not want to expose the full namespace of our Enums, we are catching the exception and re-throwing it
                // with a different message.
                try
                {
                    return base.ReadJson(reader, objectType, existingValue, serializer);
                }
                catch (JsonSerializationException)
                {
                    string values = objectType.IsEnum ? String.Join(",", Enum.GetNames(objectType)) : string.Empty;
    
                    throw new JsonSerializationException(string.Format("Error converting value {0}, possible values are: {1}",
                        objectType.Name, values));
                }
            }
        }
