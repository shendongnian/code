     [DataContract]
            public class Address
            {
                [DataMember]
                public string road { get; set; }
                [DataMember]
                public string suburb { get; set; }
                [DataMember]
                public string city { get; set; }
                [DataMember]
                public string state_district { get; set; }
                [DataMember]
                public string state { get; set; }
                [DataMember]
                public string postcode { get; set; }
                [DataMember]
                public string country { get; set; }
                [DataMember]
                public string country_code { get; set; }
            }
    
            [DataContract]
            public class RootObject
            {
                [DataMember]
                public string place_id { get; set; }
                [DataMember]
                public string licence { get; set; }
                [DataMember]
                public string osm_type { get; set; }
                [DataMember]
                public string osm_id { get; set; }
                [DataMember]
                public string lat { get; set; }
                [DataMember]
                public string lon { get; set; }
                [DataMember]
                public string display_name { get; set; }
                [DataMember]
                public Address address { get; set; }
            }
