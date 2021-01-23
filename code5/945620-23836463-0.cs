    [JsonObject(MemberSerialization.OptIn)]
    public class EligibleProviderType2
    {
        public EligibleProviderType2(){}
        [JsonProperty(PropertyName = "payer_id")]
        public string PayerID { get; set; }
        [JsonProperty(PropertyName = "names")]
        public IList<string> PayerName { get; set; }
    } // EligibleProvider
