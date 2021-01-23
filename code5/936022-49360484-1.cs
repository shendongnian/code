    [DataContract(Namespace ="")]
    public class UPDATED_ACCOUNT_DETAILS_REQUEST : BASENEW
    {
        [DataMember(Order =3)]
        public string MSISDN { get; set; }
        [DataMember(Order = 4)]
        public string IMSI { get; set; }
        [DataMember(Order = 5)]
        public string ICC_ID { get; set; }
    }
