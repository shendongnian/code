    public class Tablet
    {
        public string MacAddress { get; set; }
        [JsonConverter(typeof(VersionConverter))]
        public Version SoftwareVersion { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Charging { get; set; }
    }
