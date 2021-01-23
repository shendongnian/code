    using (var client = new HttpClient())
    {
        var json = await client.GetStringAsync("http://services.odata.org/V3/OData/OData.svc/Products?$format=json");
        var odata = JsonConvert.DeserializeObject<OData>(json);
    }
----
    public class Value
    {
        [JsonProperty("odata.type")]
        public string Type { set; get; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public string DiscontinuedDate { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
    }
    public class OData
    {
        [JsonProperty("odata.metadata")]
        public string Metadata { get; set; }
        public List<Value> Value { get; set; }
    }
