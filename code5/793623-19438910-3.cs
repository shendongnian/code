    public T GetFirstInstance<T>(string propertyName, string json)
    {
        using (var stringReader = new StringReader(json))
        using (var jsonReader = new JsonTextReader(stringReader))
        {
            while (jsonReader.Read())
            {
                if (jsonReader.TokenType == JsonToken.PropertyName
                    && (string)jsonReader.Value == propertyName)
                {
                    jsonReader.Read();
                        
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
            return default(T);
        }
    }
    public class MyType
    {
        public string Text { get; set; }
    }
    public void Test()
    {
        string json = "{ \"PropOne\": { \"Text\": \"Data\" }, \"PropTwo\": \"Data2\" }";
        MyType myType = GetFirstInstance<MyType>("PropOne", json);
        Debug.WriteLine(myType.Text);  // "Data"
    }
