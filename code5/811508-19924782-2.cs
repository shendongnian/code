    MyWebServ obj = new MyWebServ();
    IAsyncResult ar = obj.BeginFunCall(5,5,null,null);
    
    // wait for not more than 2 seconds
    ar.AsyncWaitHandle.WaitOne(2000,false);
    if (!ar.IsCompleted) //if the request is not completed  { 
      WebClientAsyncResult wcar = (WebClientAsyncResult)ar;
      wcar.Abort();//abort the call to web service 
    }
    else
    { //continue processing the results from web service }
