    [OperationContract()]
    [WebInvoke(UriTemplate = "AddPOI", ResponseFormat = WebMessageFormat.Json)]
    bool AddPOI(POIObject objPOIObject);
        [DataContract]
        public class POIObject
        {
            [DataMember]
            public string POICTG { get; set; }
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public string Description { get; set; }
            [DataMember]
            public string BestTimeToVisit{ get; set; }
            [DataMember]
            public string TimeFrom { get; set; }
            [DataMember]
            public string TimeTo { get; set; }
            [DataMember]
            public string Address { get; set; }
            [DataMember]
            public string Contact_No { get; set; }
            [DataMember]
            public string Lattitude { get; set; }
            [DataMember]
            public string Longitude { get; set; }
            [DataMember]
            public string Altitude { get; set; }
            [DataMember]
            public string Accuracy { get; set; }
            [DataMember]
            public string Image { get; set; }
            [DataMember]
            public string Video_URL { get; set; }
            [DataMember]
            public string Active_Inactive_Flag { get; set; }
            
    }
