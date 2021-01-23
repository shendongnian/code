    public class OEM
    {
        [JsonIgnore]
        public int OemID { get; set; }
        [JsonProperty(PropertyName="cars")]
        public CarInfo Cars { get; set; }
        [JsonProperty(PropertyName = "suvs")]
        public CarInfo Suvs { get; set; }
        // other properties
    }
