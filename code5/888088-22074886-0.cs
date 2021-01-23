    string json = 
         @"{ ""blah"" : { ""2"" : ""foo"", ""5"" : ""bar"", ""8"" : ""foobar"" } }";
    var dict = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
    dynamic dyn = dict["blah"];
    Console.WriteLine(dyn.GetType().FullName);     // Newtonsoft.Json.Linq.JObject
    Console.WriteLine(dyn["2"].ToString());        // foo
