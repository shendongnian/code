    try
    {
        if (channelFactory != null)
        {
            if (channelFactory.State != CommunicationState.Faulted)
            {
                channelFactory.Close();
            }
            else
            {
                channelFactory.Abort();
            }
        }
    }
    catch (CommunicationException)
    {
        channelFactory.Abort();
    }
    catch (TimeoutException)
    {
        channelFactory.Abort();
    }
    catch (Exception)
    {
        channelFactory.Abort();
        throw;
    }
    finally
    {
        channelFactory= null;
    }
