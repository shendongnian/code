    private static string GenerateCustomerId(string contextPath)
    {
        var retryMaxCount = 3;             // maximum number of attempts
        Exception exception = null;        // inner exception storage
        for (int cycles = 0; cycles < retryMaxCount; cycles++)
        {
            try
            {
                ...
                // If we get to the end of the try block, we're fine
                return customerID;
            }
            catch (NodeIsOutOfDateException e)
            {
                exception = e; // storing the exception temporarily
            }
        }
        throw new ApplicationException(
           "Node is out of date after " + retryMaxCount + " attempts.", exception);
    }
