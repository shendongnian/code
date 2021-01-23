    finally
            {
                try
                {
                    if (discoveryClient != null) 
                    { 
                      if(discoveryClient.State == CommunicationState.Faulted)
                      {
                         discoveryClient.Abort();
                      }
                      else if(discoveryClient.State != CommunicationState.Closed )
                      {
                         discoveryClient.Close();
                      }
                }
                catch (ObjectDisposedException)
                {
                                
                }
            }
