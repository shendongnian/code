    try
    { ... }
    catch (MessageSecurityException e)
    {
        Exception exc = e.InnerException;
        // Process "exc" here, depending of its type
    }
