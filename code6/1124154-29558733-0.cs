    var retsProperties = JArray.Parse(json)
        .Select(item => new RetsProperty
        {
            PropAttributes = item.First.ToObject<PropertyAttributes>(),
            ImgUrls = item.Last.ToObject<string[]>()
        })
        .ToList();
