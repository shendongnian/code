    class CustomJson : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                //if you only deserialize, you will probably not need this
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var output = new object(); //instance of your class
                do
                {
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        int number;
                        if (int.TryParse(reader.Value.ToString(), out number))
                        {
                            //detecting the number
                        }
                        else
                        {
                            //not a number
                        }
                    }
                    else
                    {
                        //read other stuff
                    }    
                } while (reader.Read());
              
                return output;
            }
    
            public override bool CanConvert(Type objectType)
            {
                //detect your type
            }
        }
