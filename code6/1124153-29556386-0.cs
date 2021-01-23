    List<RetsProperty> RetsProperties = new List<RetsProperty>();
    foreach (var prop in jsonData["Prop"])
    {
        RetsProperties.Add(new RetsProperty
            {
                ImgUrls = Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(prop.Last.ToString()),
                PropAttributes = Newtonsoft.Json.JsonConvert.DeserializeObject<PropertyAttributes>(prop.First.ToString())
            });
    };
