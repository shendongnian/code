    public IEnumerable<MobileSiteContentsContentSectionItem> Parse(string json)
    {
         dynamic jobject = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
         var result = new List<MobileSiteContentsContentSectionItem>();
         var urls = new List<string>();
         foreach (var item in jobject.MobileSiteContents)
         {
             var culture = item.Name;
             foreach(var url in item.Value)
                urls.Add(url.Value);
             result.Add(new MobileSiteContentsContentSectionItem { Culture = culture, Urls = urls.ToArray() });
         }
         return result;
    }
