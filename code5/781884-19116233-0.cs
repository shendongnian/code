    public void Disconnect()
    {
        _isconnected = false;
        OnDisconnected();
    }
