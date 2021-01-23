    // Apply the DataContract to the type
    [DataContract]
    public class RFData
    {
        // Apply the DataMemberAttribute to the various properties
        [DataMember]
        public double RFDouble { get; set; }
        [DataMember]
        public int RFInt { get; set; }
        [DataMember]
        public string RFString { get; set; }
    }
