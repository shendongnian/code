    [DataContract]
    public class OfficeToAdd
    {
         [DataMember]
         public string OfficeId;
         [DataMember]
         public string OfficeName;
    }
    
    [OperationContract]
    [WebGet(RequestFormat - WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    public void createnewAwesomeoffice(List<OfficeToAdd> offices)
    {
       ...
    }
