    public void GetOpentPos1(object sender,string accountID) 
    {
        while (1) // loop forever
        {
            GetOpentPos(sender,accountID);
            Thread.Sleep(2000);
        }
    }
    
    private void GetOpentPos (object sender,string accountID)
    {
        var request = HttpWebRequest.Create(new Uri("http://x.x.x.x/vertexweb10/webservice.svc/GetOpenPositions?AccountId="+accountID)) as HttpWebRequest;
    
        request.Method = "GET";
    
        if (request.Headers == null)
        {
            request.Headers = new WebHeaderCollection();
        }
    // My code
    } 
