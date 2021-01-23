    public class MyObject
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public IDictionary<string, object> Properties { get; set; }
    }
    public static class TestClass
    {
      public static void Test()
      {
        const string json = @"{""FirstName"": ""John"",""LastName"": ""Smith"",""Properties"": {""Email"": ""john.smith@example.com"",""Level"": 42,""Admin"": true}}";
        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
          ContractResolver = new CustomDictionaryContractResolver()
        };
        var myObject = JsonConvert.DeserializeObject<MyObject>(json);
        Debug.WriteLineIf(myObject.FirstName == "John", "FirstName is John");
        Debug.WriteLineIf(myObject.LastName == "Smith", "LastName is Smith");
        Debug.WriteLineIf(myObject.Properties != null, "Properties is not NULL");
        Debug.WriteLineIf(myObject.Properties.Count == 3, "Properties has 3 items");
        Debug.WriteLineIf(myObject.Properties.GetType() == typeof(CustomDictionary<string, object>), "Properties is CustomDictionary<,>");
        var customDictionary = myObject.Properties as CustomDictionary<string, object>;
        Debug.WriteLineIf(customDictionary != null, "Properties say " + customDictionary.Custom);
      }
    }
