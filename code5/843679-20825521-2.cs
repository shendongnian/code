    DisposableTest obj = null;
    try
    {
        obj = new DisposableTest();
    }
    catch(Exception e)
    {
    }
    finally
    {
        obj.Dispose();
    }
