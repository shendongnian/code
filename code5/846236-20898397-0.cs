    [DataContract]
    public class Station
    {
        [DataMember(Name = "stationName")]
        public string StationName { get; set; }
        [DataMember(Name = "stationId")]
        public string StationId { get; set; }
    }
