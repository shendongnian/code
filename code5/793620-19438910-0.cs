    public class MyType
    {
        public string Text { get; set; }
    }
    public MyType GetJustPropOne(string json)
    {
        using (var stringReader = new StringReader(json))
        using (var jsonReader = new JsonTextReader(stringReader))
        {
            while (jsonReader.Read())
            {
                if (jsonReader.TokenType == JsonToken.PropertyName &&
                    (string) jsonReader.Value == "PropOne")
                {
                    jsonReader.Read();
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<MyType>(jsonReader);
                }
            }
            return null;
        }
    }
    public void Test()
    {
        string json = "{ \"PropOne\": { \"Text\": \"Data\" }, \"PropTwo\": \"Data2\" }";
        MyType myType = GetJustPropOne(json);
        Debug.WriteLine(myType.Text);  // "Data"
    }
