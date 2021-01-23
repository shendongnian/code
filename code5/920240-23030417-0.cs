    proxy ServiceClient();
    try
    {
        proxy = new ServiceClient();
        proxy.DoSomething();
        proxy.Close();
    }
    catch (FaultException ex)
    {
       // handle errors returned by WCF service
    }
    catch (CommunicationException ex)
    {
      // any communication errors? 
    }
    finally
    {
       // make sure channel has been safely closed.
    }
      
