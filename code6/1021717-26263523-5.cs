    try
    {
        Task myTask = SomeOperationAsync();
        myTask.Wait();
    }
    catch (AggregateException wrapperEx)
    {
        ArgumentException ex = wrapperEx.InnerException as ArgumentException;
        if (ex == null)
            throw;
        // ex was thrown during the asynchronous portion of SomeOperationAsync. This is
        // always the case if SomeOperationAsync is an async function (§10.15 - C#
        // Language Specification Version 5.0).
    }
