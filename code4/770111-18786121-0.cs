    public class Response
    {
        [JsonProperty("msg_id")]
        public string MsgId { get; set; }
        [JsonProperty("sendondate")]
        public string Sendondate { get; set; }
        [JsonProperty("seq_id")]
        public SeqId SeqId { get; set; }
    }
    public class SeqId
    {
        [JsonProperty("1")]
        public Class1 value { get; set; }
    }
    public class Class1
    {
        [JsonProperty("valid")]
        public string Valid { get; set; }
        [JsonProperty("credit")]
        public string Credit { get; set; }
        [JsonProperty("linecount")]
        public int Linecount { get; set; }
        [JsonProperty("billcredit")]
        public int Billcredit { get; set; }
        [JsonProperty("id_provider")]
        public string IdProvider { get; set; }
        [JsonProperty("providerkey")]
        public string Providerkey { get; set; }
        [JsonProperty("regionKey")]
        public string RegionKey { get; set; }
        [JsonProperty("mnpID")]
        public string MnpID { get; set; }
        [JsonProperty("dlr_seq")]
        public int DlrSeq { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("remarks")]
        public string Remarks { get; set; }
    }
