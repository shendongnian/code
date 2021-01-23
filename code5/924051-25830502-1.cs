    ServiceContract Interface
    
    [ServiceContract]
    public interface ITasks
    {
       [OperationContract]
        [WebInvoke(Method = "POST",RequestFormat=WebMessageFormat.Json ,
          ResponseFormat =   WebMessageFormat.Json, 
          UriTemplate = "Tasks/SetTasksForMerge")]
        string CreateNewTaks(valObj[] values);        
    }
    
    [DataContract]
    public class valObj
        {
        [DataMember]
        public string taskIds { get; set; }
        [DataMember]
        public string action { get; set; }
        [DataMember]
        public string userName { get; set; }
        }
