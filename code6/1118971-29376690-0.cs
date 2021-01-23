    public class RootObject
    {
        public int num_locations { get; set; }
        public Locations locations { get; set; }
    }
    public class Locations
    {
        [JsonProperty("98765")]
        public LocationInner Inner { get; set; }
    }
    public class LocationInner
    {
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string s_status { get; set; }
        public string system_state { get; set; }
    }
