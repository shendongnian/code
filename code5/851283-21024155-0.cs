    AsyncCallback callback = ProcessAsyncResult;
    object asyncState = "TestAsyncState";
    srv.BeginAddDocument(Credentials, document, callback, asyncState);
    
    
    public void ProcessAsyncResult(IAsyncResult result)
    {
        TypeThatsrvIs s = (TypeThatsrvIs)result.AsyncState;
        //"s" will be the same srv object that you called BeginAddDocument on.
        //It "should" contain the web-service result.
        s = s.EndAddDocument(result);
        /*
        Do stuff with that resulting object.
        */
        
    }
