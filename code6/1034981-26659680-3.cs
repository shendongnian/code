    [DataContract]
    public class SomeDTO
    {
       [DataMember]
       public string Property1 {get;set;}
       public string Property2 {get;set;}
    }
     
    [ServiceContract]
    public interface RecordFindSingle
    {
        [OperationContract]
        SomeDTO FindSingleRecord(); // or whatever the method signature they gave you
    }
