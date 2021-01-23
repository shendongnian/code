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
        [DataContract]
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
        [DataContract]
        public class Dividend : DividendBase
        {
            [DataMember]
            public float Amount { get; set; }
            [DataMember]
            public DateTime ExDate { get; set; }
        }
    }
