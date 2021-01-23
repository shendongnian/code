    public class Link
    {
        public string Href { get; set; }
        public string Method { get; set; }
    }
    
    public class Links
    {
        [JsonProperty("addons")]
        public Link Addons { get; set; }
        [JsonProperty("conditions")]
        public Link Conditions { get; set; }
        [JsonProperty("conversions")]
        public Link Conversions { get; set; }
        [JsonProperty("list_prices")]
        public Link ListPrices { get; set; }
        [JsonProperty("mutual_exclusion")]
        public Link MutualExclusion { get; set; }
        [JsonProperty("prerequisites")]
        public Link Prerequisites { get; set; }
        [JsonProperty("product")]
        public Link Product { get; set; }
    }
    
    
    public class RootObject
    {
        public string dummy { get; set; }
        public Links links { get; set; }
    }
