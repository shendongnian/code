    namespace Feeder.Contract
    {
        [DataContract]
        public class DividendBase
        {
            [DataMember]
            public DateTime AnnouncementDate { get; set; }
        }
    }
    namespace Feeder.Logic
    {
        [DataContract(Namespace = "Feeder.Contracts")]
        public class Dividend : DividendBase
        {
            [DataMember]
            public float Amount { get; set; }
            [DataMember]
            public DateTime ExDate { get; set; }
        }
    }
    namespace Feeder.Data
    {
        [DataContract(Namespace = "Feeder.Contracts")]
        public class Dividend : DividendBase
        {
            [DataMember]
            public float Amount { get; set; }
            [DataMember]
            public DateTime ExDate { get; set; }
        }
    }
