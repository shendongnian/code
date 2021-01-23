    // DynamicJson - (IsObject)
    var objectJson = DynamicJson.Parse(@"{""foo"":""json"",""bar"":100}");
    foreach (KeyValuePair<string, dynamic> item in objectJson)
    {
        Console.WriteLine(item.Key + ":" + item.Value); // foo:json, bar:100
    }
