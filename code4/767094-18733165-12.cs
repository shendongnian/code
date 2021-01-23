    [WebMethod]
            [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
            public string sendRequest(Dictionary<string,string> varName)//The variable name must be same
            {
              foreach(var eachvals in varName)
              {
              string Keyval =eachvals.["Key"];
              string Value =eachvals.["Value"];
              }
        
             }
