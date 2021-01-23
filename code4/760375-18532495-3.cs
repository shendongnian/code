    try
    {
        // Do something that may fail
    }
    catch (SomeException e)
    {
        try
        {
            logger.Log(e);
        }
        catch (IOException)
        {
            // Ooops, log doesn't work. What should I do?
            // Should I display a MessageBox?
        }
    }
