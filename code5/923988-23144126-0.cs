    MyService.JobsClient Client = new MyService.JobsClient();
    Client.Endpoint.Address = new System.ServiceModel.EndpointAddress(ConfigurationManager.AppSettings["ServicePath"]);
    try
    {
        Client.WCFGetSystemState(System.Environment.MachineName); 
        Client.Close();
    }
    catch (TimeoutException timeout)
    {
        // Handle the timeout exception.
        Client.Abort();
    }
    catch (CommunicationException commException)
    {
        // Handle the communication exception.
        Client.Abort();
    }
