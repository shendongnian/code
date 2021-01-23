    [DataContract]
        public class MASInspections
        {
            [DataMember]
            public int MaintID { get; set; }
            public string MHID { get; set; }
            public DateTime MaintDate { get; set; }
            public string pdfReport { get; set; }
    
        }
