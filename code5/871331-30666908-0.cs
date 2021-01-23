    private static void CloseChannel<T>(T channel)
    {
        var clientChannel = (IClientChannel)channel;
        var success = false;
        try
        {
            //sleep before close so the main thread has a chance to catch up
            Thread.Sleep(10000);
            clientChannel.Close();
            success = true;
        }
        catch (CommunicationException ce)
        {
            clientChannel.Abort();
        }
        catch (TimeoutException te)
        {
            clientChannel.Abort();
        }
        finally
        {
            if (!success)
                clientChannel.Abort();
        }
    }
