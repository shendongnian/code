    namespace DataObjects
    {
        [DataContract]
        [KnownType(typeof(IDataItem))]
        public class DataItem : IDataItem
        {
            public DataItem();
    
            [DataMember]
            public CustomerInfo customer { get; set; }
            [DataMember]
            public LoanInfo loan { get; set; }
            [DataMember]
            public DateTime loanProcessingDate { get; set; }
            [DataMember]
            public string moduleID { get; set; }
            [DataMember]
            public string processingState { get; set; }
        }
    }
