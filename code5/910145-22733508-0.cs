    var json = JsonConvert.SerializeObject(new Dictionary<string, object> { { "123", 10 } });
    var deserialized = JsonConvert.DeserializeObject<object>(json);
    
    // using the IDictionary interface
    var ten = ((IDictionary<string, JToken>)deserialized)["123"].Value<JValue>().Value;
    Console.WriteLine(ten.GetType() + " " + ten); // System.Int64 10
    // using dynamic
    dynamic d = deserialized;
    Console.WriteLine(d["123"].Value.GetType() + " " + d["123"].Value); // System.Int64 10
