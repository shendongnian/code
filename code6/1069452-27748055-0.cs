    public static void Main()
    {
    
        string url = "http://anus.io";
    
        ***int DefaultTimeOut = 15000;*** //timeout after 15 sec
    
        Console.WriteLine("Initializing Request State Object");
    
        RequestState myRequestState = new RequestState();
    
        // Creating Http Request
        myRequestState.request  =  (HttpWebRequest)WebRequest.Create(url);
        myRequestState.request.Method           = "GET";
        myRequestState.request.ReadWriteTimeout = 4000;
        myRequestState.request.Timeout          = 4000;
    
        Console.WriteLine("Begining Async Request");
    
    
        IAsyncResult ar = myRequestState.request.BeginGetResponse(new AsyncCallback(ResponseCallback), myRequestState);
        ***ThreadPool.RegisterWaitForSingleObject(ar.AsyncWaitHandle, new WaitOrTimerCallback(TimeoutCallback), myRequestState.Request, DefaultTimeout, true);***
    
        Console.WriteLine("Waiting for Results");
        ar.AsyncWaitHandle.WaitOne();
    
        myRequestState.response = (HttpWebResponse)myRequestState.request.EndGetResponse(ar);
        Console.WriteLine("Response status code = {0}", myRequestState.response.StatusCode);
    
    }
    
    public static void ResponseCallback (IAsyncResult asyncResult)
    {
        Console.WriteLine("Completed");
    }
    
    //call the timeout if more than 15 seconds
    
    **static void TimeoutCallback(object state, bool timedOut)
    {
                if (timedOut)
                {
                    HttpWebRequest request = state as HttpWebRequest;
                    if (request != null)
                    {
                        request.Abort();
                    }
                }
    }**
    
    }
