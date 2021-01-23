    [DataContract]
    public class NightlyRate
    {
        [DataMember(Name="@baseRate")]
        public string baseRate { get; set; }
        [DataMember(Name="@promo")]
        public string promo { get; set; }
 
        [DataMember(Name="@rate")]
        public string rate { get; set; }
    }
