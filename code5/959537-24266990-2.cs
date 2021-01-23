    [DataContract]
    public class officetoadd
    {
         [DataMember]
         public string officeid;
         [DataMember]
         public string officename;
    }
    
    [OperationContract]
    [WebGet(RequestFormat - WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    public void createnewAwesomeoffice(List<officetoadd> listoffice)
    {
       ...
    }
