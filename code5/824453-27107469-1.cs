     public String SayHello(String request)
                {
                    object activityId;
                    System.ServiceModel.OperationContext.Current.IncomingMessageProperties.TryGetValue("LOGID", out activityId);
        
        //log your messages here with this ID....
    
    Return "Hello, World";
        }
