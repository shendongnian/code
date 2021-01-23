    finally
            {
                try
                {
                    if (discoveryClient != null &&
                        (discoveryClient.State!= CommunicationState.Closing ||
                         discoveryClient.State!= CommunicationState.Closed )
                    {
                        discoveryClient.Close();
                    }
                }
                catch (ObjectDisposedException)
                {
                                
                }
            }
