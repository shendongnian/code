    public System.ServiceModel.Channels.Message CreateJsonResponse()
    {
      List<Customer> response = GetCustomers(); 
      
      string msg = JsonConvert.SerializeObject(response);
    
      return WebOperationContext.Current.CreateTextResponse(msg, "application/json; charset=utf-8", Encoding.UTF8);
    }
