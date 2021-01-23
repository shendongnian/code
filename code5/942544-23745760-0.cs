    [DataContract]
    public class User
    {
       [DataMember]
       public int Id {get;set;}
       [DataMember]
       public string UserName {get;set;}
       [DataMember]
       public string Password {get;set;}
    }
