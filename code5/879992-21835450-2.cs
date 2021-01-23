    [DataContract]
    public class ResponseObj
    {
       [DataMember]        
       public int ErrorId {get;set;}
       [DataMember]
       public string ErrorMessage {get;set;}
       [DataMember]
       public string MessageImportance {get;set;}
       [DataMember]
       public int Id {get;set;}
       [DataMember]
       public List<string> Name {get;set;}
    }
