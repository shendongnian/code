    [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string sendRequest(List<MyObject> varName)//The variable name must be same
        {
          foreach(var eachvals in varName)
          {
          string Keyval =eachvals.Key;
          string Value =eachvals.Value;
          }
    
         }
    public class MyObject 
    {
    public string Key {get;set};
    public string Value {get;set;}
    }
