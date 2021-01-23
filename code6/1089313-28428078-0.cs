    if (_client != null) 
    {
        if (_client.State != CommunicationState.Faulted)
        {
            _client.Close();
        }
        else
        {
            _client.Abort(); // Use when channel is faulted
        }
        
        // Now you can check for closed state etc...
        if (_client.State != CommunicationState.Closed)
        {
            return _client;
        }
    }
    
    _client = new SmartServiceClient();
    return _client;
