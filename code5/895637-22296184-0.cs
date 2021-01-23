    var list = JObject.Parse(json)
                        .Descendants()
                        .OfType<JProperty>()
                        .Where(p => p.Name == "OfferPixel")
                        .Select(x => x.Value.ToObject<OfferPixel>())
                        .ToList();
----
    public class OfferPixel
    {
        public string id { get; set; }
        public string affiliate_id { get; set; }
        public string offer_id { get; set; }
        public string status { get; set; }
        public string code { get; set; }
        public string type { get; set; }
        public string modified { get; set; }
        public object goal_id { get; set; }
    }
