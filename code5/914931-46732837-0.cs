    try
    {
        // something dangerous
    }
    catch (AggregateException ae)
    { 
        foreach(Exception innerException in ae.Flatten().InnerExceptions)
        {
            Console.WriteLine(innerException.Message());
        }
    }
