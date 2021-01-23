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
      // handle communication errors here 
      proxy.Abort();
    }
    catch (TimeOutException ex)
    {
      // handle timeouts here 
      proxy.Abort();
    }
    catch (Exception ex)
    {
      // handle unaccounted for exception here 
    }
    finally
    {
      // Safely close connection
      
    }
      
