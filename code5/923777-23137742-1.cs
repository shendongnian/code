    private void WorkCallback(IAsyncResult ar)
    {
        AsyncResult result = (AsyncResult)ar;
        AsyncWorkCaller caller = (AsyncWorkCaller)result.AsyncDelegate;
        string returnValue = caller.EndInvoke(ar);
        //manipulate the new s value here
     }
