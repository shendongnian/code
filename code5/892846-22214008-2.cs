    [WebMethod]
    [ScriptMethod(UseHttpGet = true)]
    public PolicyGeneratorResponse PolicyGenerator(string fileName){
          return new PolicyGeneratorResponse(...);
    }
    
    ...
    
    class PolicyGeneratorResponse {
        public string res;
    }
