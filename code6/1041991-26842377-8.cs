    private void SendMessageToLogger()
    {
        using (ChannelFactory<IFromClientToServerMessages> factory = new ChannelFactory<IFromClientToServerMessages>(new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/Server")))
        {
           IFromClientToServerMessages clientToServerChannel = factory.CreateChannel();
                    try
                    {
                        clientToServerChannel.DisplayTextOnServerAsFromThisClient("Message to be displayed");
                    }
                    catch (Exception ex)
                    {                   
                    }
                    finally
                    {
                        CloseChannel((ICommunicationObject)clientToServerChannel);
                    }
                }
            }
Closing the communication channel
    private void CloseChannel(ICommunicationObject channel)
    {
      try
      {
         channel.Close();
      }
      catch (Exception ex)
      {
    
      }
      finally
      {
         channel.Abort();
      }
    }
