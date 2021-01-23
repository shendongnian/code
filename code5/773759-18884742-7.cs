        [DataContract]
        public class ApiData
        {
            [DataMember(Name = "name")]  <--this name must be the exact name of the json key
            public string Name { get; set; }
            [DataMember(Name = "description")]
            public string Description { get; set; }
        }
