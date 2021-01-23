    using System;
    using Newtonsoft.Json.Linq;
    JObject resultData = JObject.Parse(result);
    foreach (JToken item in resultData.Children())
    {
        Console.WriteLine(item.First.SelectToken("id"));
    }
