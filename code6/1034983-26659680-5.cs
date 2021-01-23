    [DataContract]
    public class Record
    {
        [DataMember]
        public string Property1 {get;set;}
        [DataMember]
        public string Property2 {get;set;}
        // Continue listing all properties ...
    }
     
    [ServiceContract]
    public interface RecordFindSingle
    {
        [OperationContract]
        Record FindSingleRecord(string Source , int RecordNo);
    }
