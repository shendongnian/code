    public class ItemResults
    {
        public int Id { get; set; }
        public DateTime Activation_Date { get; set; }
        public DateTime Expiration_Date { get; set; }
        public string Title { get; set; }
        [JsonProperty("locations")]
        public JObject JsonLocations { get; set; }
        [JsonIgnore]
        public List<Location> Locations { get; set; }
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            this.Locations = new List<Location>();
            foreach (KeyValuePair<string, JToken> item in this.JsonLocations)
            {
                this.Locations.Add(new Location() { Id = int.Parse(item.Key), value = item.Value.ToString() });
            }
        }
    }
    public class Location
    {
        public int Id { get; set; }
        public string value { get; set; }
    }
