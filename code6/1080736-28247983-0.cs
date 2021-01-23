    class ServiceMessageConverter : CustomCreationConverter<ServiceMessage>
    {
        public override ServiceMessage Create(Type objectType)
        {
            return new ServiceMessage();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var msg = new ServiceMessage();
            string data_string = "";
            //get an array of the object's props so I can check if the JSON prop s/b mapped to it
            var objProps = objectType.GetProperties().Select(p => p.Name.ToLower()).ToArray();
            while (reader.Read())
            {
                if (reader.Value == null)
                {
                    continue;
                }
                // read the property name
                string readerValue = reader.Value.ToString().ToLower();
                // read the property value
                if (reader.Read())
                {
                    // make sure the complex types are saved as strings
                    if (readerValue.ToLower() == "data")
                    {
                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            dynamic data_obj = serializer.Deserialize(reader);
                            data_string = data_obj.ToString();
                        }
                        else if (reader.TokenType == JsonToken.StartArray)
                        {
                            dynamic data_obj = serializer.Deserialize(reader);
                            data_string = data_obj.ToString();
                        }
                        else
                        {
                            data_string = reader.Value.ToString();
                        }
                        // stuff the data element value into the ServiceMessage
                        PropertyInfo pi = msg.GetType().
                            GetProperty("data", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                        pi.SetValue(msg, data_string);
                    }
                    else
                    {
                        // stuff the value into the ServiceMessage
                        PropertyInfo pi = msg.GetType().
                            GetProperty(readerValue, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                        var convertedValue = Convert.ChangeType(reader.Value, pi.PropertyType);
                        pi.SetValue(msg, convertedValue, null);
                    }
                }
            }
            return msg;
        }
    }
