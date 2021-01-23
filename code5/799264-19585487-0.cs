    var queueMessage = Queue.GetMessage();    
    try
    {
        pipeline.Process(queueMessage);
    }
    catch (Exception ex)
    {
        Logger.LogException(ex);
    }
    finally
    {
        Queue.DeleteMessage(queueMessage);//Will be executed for sure*
    }
