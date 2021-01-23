    [DataContract]
    public class Response
    {
       [DataMember]
       public bool Success {get;set;}
       [DataMember]   
       public string Message {get;set;}
       [DataMember]
       public List<User> Users {get;set;}
    }
