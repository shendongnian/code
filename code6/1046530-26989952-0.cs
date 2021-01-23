    var car = new Car() { Name = "Ford", Owner = "John Smith" };
    string json = Serialize(car);
---
    string Serialize<T>(T o)
    {
        var attr = o.GetType().GetCustomAttribute(typeof(JsonObjectAttribute)) as JsonObjectAttribute;
        var jv = JValue.FromObject(o);
        return new JObject(new JProperty(attr.Title, jv)).ToString();
    }
