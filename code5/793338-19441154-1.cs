    public IEnumerable<MobileSiteContentsContentSectionItem> Parse(string json)
    {
        return JObject.Parse(json)["MobileSiteContents"]
            .Children<JProperty>()
            .Select(prop => new MobileSiteContentsContentSectionItem
            {
                Culture = prop.Name,
                Urls = prop.Value.ToObject<string[]>()
            })
            .ToList();
    }
