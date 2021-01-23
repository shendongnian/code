    using System;
    using Newtonsoft.Json.Linq;
    JObject resultData = JObject.Parse(result);
    foreach (var item in resultData)
    {
        Console.WriteLine(item.Key); // this will print "bloxwich" for your example
        Console.WriteLine("Item: " + item.Value.SelectToken("id"));
    }
