    public T GetFirstInstance<T>(string propertyName, string json)
    {
        using (var stringReader = new StringReader(json))
        using (var jsonReader = new JsonTextReader(stringReader))
        {
            int level = 0;
            while (jsonReader.Read())
            {
                switch (jsonReader.TokenType)
                {
                    case JsonToken.PropertyName:
                        if (level != 1)
                            break;
                        if ((string)jsonReader.Value == propertyName)
                        {
                            jsonReader.Read();
                            return (T)jsonReader.Value; 
                        }
                        break;
                    case JsonToken.StartArray:
                    case JsonToken.StartConstructor:
                    case JsonToken.StartObject:
                        level++;
                        break;
                    case JsonToken.EndArray:
                    case JsonToken.EndConstructor:
                    case JsonToken.EndObject:
                        level--;
                        break;
                }
            }
            return default(T);
        }
    }
