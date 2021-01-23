        public class file1
        {
            [DataContract]
            public class child
            {
                [DataMember(Name="version")]
                public string Version { get; set; }
                [DataMember(Name="results")]
                public List<parent> Results { get; set; }
            }
            [DataContract]
            public class parent
            {
                [DataMember(Name="company")]
                public string Company { get; set; }
                [DataMember(Name="city")]
                public string City { get; set; }
                [DataMember(Name="state")]
                public string State { get; set; }
            }
        }
