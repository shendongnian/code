    static async Task AsynchronyWithTPL()
    {
        try
        {
            Console.WriteLine(await GetInfoAsync("Task 1"));    
        }
        catch (AggregateException exception)
        {
            Console.WriteLine(exception.InnerException);
        }
    }
