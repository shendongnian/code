    var json = @"{ ""Time"": ""2015-10-28T14:05:22.0091621+00:00""}";
    Console.WriteLine(json);
    // Result: { "Time": "2015-10-28T14:05:22.0091621+00:00" }
    var jObject1 = JObject.Parse(json);
    Console.WriteLine(jObject1.ToString());
    // Result: { "Time": "2015-10-28T15:05:22.0091621+01:00" }
    
    var jObject2 = Newtonsoft.Json.JsonConvert.DeserializeObject(json, 
      new Newtonsoft.Json.JsonSerializerSettings 
      { 
        DateParseHandling = Newtonsoft.Json.DateParseHandling.DateTimeOffset 
      });
    Console.WriteLine(jObject2.ToString());
    // Result: { "Time": "2015-10-28T14:05:22.0091621+00:00" }
