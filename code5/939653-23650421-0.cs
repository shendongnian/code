    private enum State
    {
       MessageLength
       MessageData
    }
    
    private State _state;
    private void OnEndReceive(IAsyncCallback ia)
    {
        int bytesRead = _socket.EndReceive(ia);
    
        if (_state == MessageLength) 
        {
            // read and store the message length byte
        }
        else if (_state == State.MessageData)
        {
            // read message data up to the number of bytes received .
            // if there's data left to be read for the current message, read it.
            // if more bytes have been received than there is message data, it means there's a 
            // new message already waiting
        }
    
    }
