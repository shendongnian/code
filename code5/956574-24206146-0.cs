    while (true)
            {
                try
                {
                    return request.GetResponse() as HttpWebResponse;
                }
                catch (Exception e)
                {
                    if (e is WebException && allowedRetries-- > 0)
                    {
                        System.Console.WriteLine("Trying to Reconnect...");
                        Thread.Sleep((int)millisecondsDelay);
                        //millisecondsDelay *= delayMultiplyFactor;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
