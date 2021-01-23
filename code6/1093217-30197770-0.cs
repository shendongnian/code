    try
    { ... }
    catch (MessageSecurityException e)
    {
        Exception fault = e.InnerException;
        // Process "fault" here, depending of its type
    }
