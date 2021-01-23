    Service1Client proxy = null;
    
    try
    {
        Console.WriteLine("Calling service");
        proxy = new Service1Client();
        return await proxy.DoWorkAsync();
    }
    finally
    {
        if (proxy != null)
        {
            if (proxy.State == CommunicationState.Faulted)
            {
                Console.WriteLine("Aborting client");
                proxy.Abort();
            }
            else
            {
                Console.WriteLine("Closing client");
                proxy.Close();
            }
        }
    }
