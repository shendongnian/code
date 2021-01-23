    static void Main()
    {
        Test().Wait();
    }
    static async Task Test()
    {
        try
        {
            await ThrowAggregate();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    static async Task ThrowAggregate()
    {
        ThrowException().Wait();
    }
    static async Task ThrowException()
    {
        throw new OperationCanceledException();
    }
