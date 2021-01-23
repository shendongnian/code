    Task processTask = Task.Factory.StartNew(() => Process(message));
    
    bool isProcessSuccess = processTask.Wait(shared.ConfigReader.SyncWebServiceWaitTime);
                    
    if (!isProcessSuccess)
    { 
     //handle error … 
    }
