    int bytesNeeeded;
    int bytesRead;
    public void Start()
    {
        bytesNeeeded = 40; // u need to know how much bytes you're needing
        bytesRead = 0;
        BeginReading();
    }
    public void BeginReading()
    {
        myNetworkStream.BeginRead(
            someBuffer, bytesRead, bytesNeeeded - bytesRead, 
            new AsyncCallback(EndReading), 
            myNetworkStream);
    }
    public void EndReading(IAsyncResult ar)
    {
        numberOfBytesRead = myNetworkStream.EndRead(ar);
        if(numberOfBytesRead == 0)
        {
            // disconnected
            return;
        }
        bytesRead += numberOfBytesRead;
        if(bytesRead == bytesNeeded)
        {
            // Handle buffer
            Start();
        }
        else
            BeginReading();
    }
