    string json = @"{""header"":3,""data"":{""result"":""myResult""}}";
    using (var stringReader = new StringReader(json))
    {
        using (var jsonReader = new JsonTextReader(stringReader))
        {
            while (jsonReader.Read())
            {
                if (jsonReader.TokenType == JsonToken.PropertyName 
                    && jsonReader.Value != null
                    && jsonReader.Value.ToString() == "header")
                {
                    jsonReader.Read();
                    int header = Convert.ToInt32(jsonReader.Value);
                    switch (header)
                    {
                        case 1:
                            // Deserialize as type 1
                            break;
                        case 2:
                            // Deserialize as type 2
                            break;
                        case 3:
                            // Deserialize as type 3
                            break;
                    }
                    break;
                }
            }
        }
    }
