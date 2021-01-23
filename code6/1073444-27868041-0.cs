    [DataMember(Name = "parameters")]
    public List<Dictionary<string, object>> Parameters { get; set; }
    // or
    [DataMember(Name = "parameters")]
    public List<Dictionary<string, string>> Parameters { get; set; }
    // e.g.
    var myNewObject = JsonConvert.DeserializeObject<MyClass>(json);
    
    foreach (var dict in myNewObject.Parameters)
    {
        foreach (var pair in dict)
        {
            Console.WriteLine("\t\tKey is {0}", pair.Key);
            Console.WriteLine("\t\tValue is {0}", pair.Value);
        }
    }
