    [DataContract]
        public class MASInspections
        {
            [DataMember]
            public int MaintID { get; set; }
            [DataMember]
            public string MHID { get; set; }
            [DataMember]
            public DateTime MaintDate { get; set; }
            [DataMember]
            public string pdfReport { get; set; }
    
        }
