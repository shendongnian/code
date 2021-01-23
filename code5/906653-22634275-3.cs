    static void Main(string[] args)
    {
        try {
            DoWorkAsync().Wait();
        }
        catch (Exception ex) 
        {
            // log
            logger.Error(ex);
            throw; // re-throw to terminate
        }
    }
