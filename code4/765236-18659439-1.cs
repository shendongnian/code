    var obj = new { x = new { a = 1, b = 2 }, y = new { c = 3, d = 4 } };
    var props = JToken.FromObject(obj)
                .Children()
                .Cast<JProperty>()
                .SelectMany(x => x.Value.Children())
                .Cast<JProperty>()
                .ToDictionary(p => p.Name, p => p.Value);
            
    var json = JsonConvert.SerializeObject(props);
