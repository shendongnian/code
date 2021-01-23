    void Send(Guid param)
    {
        try
        {
            LogSend(param);
            doSend(param);
        }
        catch (SendException e)
        {
            HandleSendException(e, param);
        }
    }
