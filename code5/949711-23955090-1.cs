    [DataContract]
    public class NightlyRatesPerRoom
    {
        [DataMember]
        public List<NightlyRate> NightlyRate { get; set; }
        [DataMember(Name="@size")]
        public int size { get; set; }
    }
