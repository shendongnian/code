            while (reader.Read() && reader.TokenType != JsonToken.EndObject)
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = reader.Value.ToString();
                    if (reader.Read())
                    {
                        switch (propertyName)
                        {
                            case "Data1":
                                {
                                    // Expecting a double value.
                                    if (reader.TokenType == JsonToken.Integer || reader.TokenType == JsonToken.Float)
                                        myClass.Data1 = Convert.ToDouble(reader.Value);
                                    else
                                    {
                                        // Unknown value, skip or throw an exception
                                        JToken.Load(reader);
                                    }
                                }
                                break;
                            case "Data2":
                                {
                                    // For example
                                    myClass.Data2 = serializer.Deserialize<List<double>>(reader);
                                }
                                break;
                            case "Data3":
                                {
                                    // Expecting a string value.
                                    myClass.Data3 = JToken.Load(reader).ToString();
                                }
                                break;
                            default:
                                {
                                    // Unknown property, skip or throw an exception
                                    var unknownValue = JToken.Load(reader);
                                    Debug.WriteLine(string.Format("Uknown property \"{0}\" with value: {1}", propertyName, unknownValue));
                                }
                                break;
                        }
                    }
                }
            }
