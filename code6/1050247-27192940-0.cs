    [OperationContract]
    CompositeType GetDataUsingDataContract(CompositeType composite);
    [DataContract]
    public class CompositeType 
    {
        [DataMember]
        public bool BoolValue { get; set; }
       
        [DataMember]
        public string StringValue { get; set; }
    }
