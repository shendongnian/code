    public IEnumerable<MobileSiteContentsContentSectionItem> Parse(string json)
    {
        var jObject = JObject.Parse(json);
        var result = new List<MobileSiteContentsContentSectionItem>();
        foreach (var item in jObject["MobileSiteContents"].Children<JProperty>())
        {
            var culture = item.Name;
            string[] urls = item.Value.ToObject<string[]>();
            result.Add(new MobileSiteContentsContentSectionItem { Culture = culture, Urls = urls });
        }
        return result;
    }
