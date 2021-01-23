    byte[] byData = System.Text.Encoding.ASCII.GetBytes("Connected");
    listener.Send(byData);
    waitForData(listener);
    void waitForData(SocketState state)
        {
            try
            {
                state.Socket.BeginReceive(state.DataBuffer, 0, state.DataBuffer.Length, SocketFlags.None, new AsyncCallback(readDataCallback), state);
            }
            catch (SocketException se)
            {
                //Socket has been closed  
                //Close/dispose of socket
            }
        }
    
        public void readDataCallback(IAsyncResult ar)
        {
            SocketState state = (SocketState)ar.AsyncState;
            try
            {
                // Read data from the client socket.
                int iRx = state.Socket.EndReceive(ar);
    
                //Handle Data....
    
                waitForData(state);
            }
            catch (ObjectDisposedException)
            {
                //Socket has been closed  
                //Close/dispose of socket
            }
            catch (SocketException se)
            {
                //Socket exception
                //Close/dispose of socket
            }
        }
