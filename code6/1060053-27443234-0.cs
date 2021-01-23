    class Program
    {
      static void Main(string[] args)
      {
        var myData = new Dictionary<string, ExampleDataClass>()
        {
          { "First", new ExampleDataClass() { Name = "John", Surname = "Doe" } },
          { "Second", new ExampleDataClass() { Name = "Foo", Surname = "Bar" } }
        };
        var fileName = @"C:\MyPath\dict.xml";
        myData.SaveToXml(fileName);
        myData.Clear();
        myData = MySerializer.LoadFromXml<string, ExampleDataClass>(fileName);
      }
    }
    public class ExampleDataClass
    {
      public string Name { get; set; }
      public string Surname { get; set; }
    }
    public class KeyValue<TKey, TValue>
    {
      public TKey Key { get; set; }
      public TValue Value { get; set; }
    }
    static class MySerializer
    {
      public static void SaveToXml<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, string fileName)
      {
        var serializer = new XmlSerializer(typeof(List<KeyValue<TKey, TValue>>));
        using (var s = new StreamWriter(fileName))
        {
          serializer.Serialize(s, dictionary.Select(x => new KeyValue<TKey, TValue>() { Key = x.Key, Value = x.Value }).ToList());
        }
      }
      public static Dictionary<TKey, TValue> LoadFromXml<TKey, TValue>(string fileName)
      {
        var serializer = new XmlSerializer(typeof(List<KeyValue<TKey, TValue>>));
        using (var s = new StreamReader(fileName))
        {
          var list = serializer.Deserialize(s) as List<KeyValue<TKey, TValue>>;
          return list.ToDictionary(x => x.Key, x => x.Value);
        }
      }
    }
