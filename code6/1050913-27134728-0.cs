    public void DoSomething()
    {
      IWcfServiceAgent agent = new WcfServiceAgentProxy();
    
      var request = new DoSomethingRequest();
    
      var iar = agent.BeginDoSomething(request, null, null);
  
      //Do some other time consuming work that does not depend on the response.    
      var response = agent.EndDoSomething(iar); //This blocks till DoSomething completes.
    
      //Do something with the response.
    
    }
