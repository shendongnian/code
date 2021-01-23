    int X = 0, Z = 1;
    dict[X].Add("Key1", CarObject);
    dict[X].Add("Key2", SellerObject);
    dict[X].Add("Key3", Z);
    var results = dict[X].Where(x => (x.Value is CarObject) && ((CarObject)x.Value).Name.Contains("X1")).Select(x => x.Value);
    foreach (var str in results)
       Console.WriteLine(str);
