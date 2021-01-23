    [OperationContract]
    [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "json")]
    public string ExecuteAction(string action, string args)
    {
       String JSONResult = String.Empty;
       MethodInfo action = services.GetMethod(action, BindingFlags.NonPublic |    BindingFlags.Public | BindingFlags.Static);
       JSONResult =(String)action.Invoke(null, new object[] { args });
    }
