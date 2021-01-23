    public Message CreateJsonResponse()
    {
      var response = ResponseSource(); // can return any serializable complex type
      
      string msg = response == null ? string.Empty : JsonConvert.SerializeObject(response);
    
      return WebOperationContext.Current.CreateTextResponse(msg, "application/json; charset=utf-8", Encoding.UTF8);
    }
