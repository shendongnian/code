    proxy ServiceClient();
    try
    {
        proxy = new ServiceClient();
        proxy.DoSomething();
    }
    catch (FaultException ex)
    {
       // handle errors returned by WCF service
    }
    catch (CommunicationException ex)
    {
      // handle communication errors here 
    }
    catch (TimeOutException ex)
    {
      // handle timeouts here 
    }
    catch (Exception ex)
    {
      // handle unaccounted for exception here 
    }
    finally
    {
       if (proxy.State == CommunicationState.Opened)
       {
          proxy.Close();
       }
       else
       {
          proxy.Abort();
       }     
    }
      
