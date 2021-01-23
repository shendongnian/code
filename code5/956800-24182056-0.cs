    private void ReceiveCallback(IAsyncResult AR)
    {
            try
            {
                int bytesTransferred = resultState.Socket.EndReceive(ar);                    
                if (bytesTransferred == 0) return; // Closed
                string text = Encoding.ASCII.GetString(_buffer, 0, bytesTransferred);
                write(text);
                // Read more
                _client_socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
            }
            catch (Exception e)
            {
                // Error handling                  
            }
            
    }
