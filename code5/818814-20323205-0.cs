    public bool Connected 
    {
        get 
        {
             return _socket.Connected; // Possible NullRef here!!!
        }
    } 
