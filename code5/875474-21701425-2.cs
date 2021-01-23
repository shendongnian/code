    [OperationContract]
    [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "json")]
    public string ExecuteAction(JSONRequest request)
    {
       String JSONResult = String.Empty;
       MethodInfo action = services.GetMethod(action, BindingFlags.NonPublic |    BindingFlags.Public | BindingFlags.Static);
       JSONResult =(String)action.Invoke(null, new object[] { args });
    }
    [DataContract]
    public class JSONRequest
    {
       [DataMember]
       public string Action {get; set;}
       [DataMember]
       public string Args {get; set;}
    }
