    var dic1 = new Dictionary<String, String>();
    dic1.Add("Key 2", "Value 2");
    dic1.Add("Key 1", "Value 1");
    var dic2 = new Dictionary<String, String>();
    dic2.Add("Key 1", "Value 1");
    dic2.Add("Key 2", "Value 2");
    bool areEqual = dic1.OrderBy(x => x.Key).Select(x => x.Value.ToUpper())
         .SequenceEqual(dic2.OrderBy(x => x.Key).Select(x => x.Value.ToUpper()));
    Console.WriteLine(areEqual);
