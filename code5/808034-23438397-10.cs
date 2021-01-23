    try
    {
        if (channel != null)
        {
            if (channel.State != CommunicationState.Faulted)
            {
                channel.Close();
            }
            else
            {
                channel.Abort();
            }
        }
    }
    catch (CommunicationException)
    {
        channel.Abort();
    }
    catch (TimeoutException)
    {
        channel.Abort();
    }
    catch (Exception)
    {
        channel.Abort();
        throw;
    }
    finally
    {
        channel = null;
    }
