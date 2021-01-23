    if (mySemaphore.WaitOne(0)) 
    {
        try
        {
            DoSomething();
        }
        finally
        {
            //Only call release when WaitOne returns true, also put it in a finally 
            //block to make sure it always gets called.
            mySemaphore.Release();
        }
    }
    else
    {
        //Do something else because the resource was not available.
    }
