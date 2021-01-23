            [DataContract]
            [KnownType(typeof (Offer))]
            public class HomePage {
              
                [DataMember]
                public List<Offer> Featured { get; set; }
            }
        
            internal class Program {
                private static void Main(string[] args) {
                }
            }
        
            public class Offer {
                public string offerTitle { get; set; }
                public string offerDescription { get; set; }
                public string offerLocation { get; set; }
            }
