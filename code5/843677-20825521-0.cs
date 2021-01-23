    DisposableTest obj = default(DisposableTest);
    try
    {
        DisposableTest obj = new DisposableTest();
    }
    finally
    {
        obj.Dispose();
    }
