        [DataContract]
        class Club
        {
            [DataMember(Name = "Id")]
            public int Id { get; set; }
            [DataMember(Name = "Name")]
            public string Name { get; set; }
            [DataMember(Name = "Street")]        
            public string Street { get; set; }
            [DataMember(Name = "Zip")]
            public string Zip { get; set; }
            [DataMember(Name = "City")]
            public string City { get; set; }
            [DataMember(Name = "Canton")]
            public string Canton { get; set; }
            [DataMember(Name = "Phone")]
            public string Phone { get; set; }
            [DataMember(Name = "Url")]
            public string Url { get; set; }
        }
