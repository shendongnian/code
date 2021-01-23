    private long _lastBytesRecevied;
    private long _lastBytesSent;
    private DateTime _lastReceivedMesurement;
    private DateTime _lastSentMesurement;
    
    //This needs to be done once at the start of the class to "seed" the first value.
    private Init()
    {
        _lastReceivedMesurement = DateTime.UtcNow;
        _lastBytesRecevied = interfaceStats.BytesReceived;
    
        _lastSentMesurement = DateTime.UtcNow;
        _lastBytesSent = interfaceStats.BytesSent;
    }
    private double getKBDownloadSpeed()
    {
        double result = (interfaceStats.BytesReceived - _lastBytesRecevied) / (DateTime.UtcNow - _lastMesurement).TotalSeconds;
    
        _lastReceivedMesurement = DateTime.UtcNow;
        _lastBytesRecevied = interfaceStats.BytesReceived;
    
        return result / 1024d;
    }
    
    private double getKBUploadSpeed()
    {
        double result = (interfaceStats.BytesSent - _lastBytesSent) / (DateTime.UtcNow - _lastSentMesurement).TotalSeconds;
        _lastSentMesurement = DateTime.UtcNow;
        _lastBytesSent = interfaceStats.BytesSent;
        return result / 1024d;
    }
