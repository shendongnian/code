    DisposableTest obj = new DisposableTest();
    try
    {
        obj.DoSomeUnsafeActions();
    }
    catch(Exception e)
    {
    }
    finally
    {
        obj.Dispose();
    }
