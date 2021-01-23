    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.Serialization;
    namespace BusinessLogic
    {
         [DataContract]
         [Serializable]
         public class POSTheaterListArgs
        {
        public POSTheaterListArgs()
        {
            TheaterDates = new List<string>();
        }
        [DataMember]
        public List<string> TheaterDates { get; set; }
        [DataMember]
        public int TheaterId { get; set; }
        [DataMember]
        public int NumofScreen { get; set; }
        [DataMember]
        public int? CompanyId { get; set; }
        [DataMember]
        public int ChainId { get; set; }
        [DataMember]
       
        private int _Number;
        public int Number { get { return _Number; } set { _Number = value; } }
        private bool _status;
        public bool status { get { return _status; } set { _status = value; } }
    }
