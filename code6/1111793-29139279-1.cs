    logger.LogAsync(...).ContinueWith(x => {
        // check task
        if (x.IsFaulted)
        {
            // you need to touch x.Exception property here
            // or your application will crash because of unhandled exception
            Console.WriteLine("LogAsync error occured: {0}", x.Exception);
        }
        try
        {
            logger.Close();
        }
        catch (CommunicationException e)
        {
            logger.Abort();
        }
        catch (TimeoutException e)
        {
            logger.Abort();
        }
        catch (Exception e)
        {
            // you will want to log this exception to log file
            Console.WriteLine("LogAsync client close error: {0}", e);
            logger.Abort();
            // no throw here or your application will crash
        }
    });
