    double millisecondsDelay = 10;
    double delayMultiplyFactor = 2;
    int allowedRetries = 10;
    while (true)
    {
        try
        {
            return request.GetResponse() as HttpWebResponse;
        }
        catch (Exception e)
        {
            if (e is /* RecoverableException*/ && allowedRetries-- > 0)
            {
                Thread.Sleep((int)millisecondsDelay);
                millisecondsDelay *= delayMultiplyFactor;
            }
            else
            {
                throw;
            }
        }
    }
