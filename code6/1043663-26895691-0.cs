    string json = "{\"options\":{\"01\":{\"enabled\":01,\"string\":\"Battery\"},\"02\":{\"enabled\":00,\"string\":\"Steering Sensor\"}}}";
    var serializer = new JavaScriptSerializer();
    var root = serializer.Deserialize<Root>(json);
    foreach (var item in root.options)
    {
        Console.WriteLine(item.Key + ": " + item.Value.enabled + "," + item.Value.@string);
    }
---
    public class Item
    {
        public int enabled { get; set; }
        public string @string { get; set; }
    }
    public class Root
    {
        public Dictionary<string, Item> options { get; set; }
    }
