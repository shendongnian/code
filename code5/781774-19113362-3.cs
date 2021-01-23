    int bytesNeeded;
    int bytesRead;
    public void Start()
    {
        bytesNeeded = 40; // u need to know how much bytes you're needing
        bytesRead = 0;
        BeginReading();
    }
    public void BeginReading()
    {
        myNetworkStream.BeginRead(
            someBuffer, bytesRead, bytesNeeded - bytesRead, 
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
