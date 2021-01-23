        private void RecieveCallback(IAsyncResult ar)
        {
            try 
            {
                int bytesReceived = _client_socket.EndReceive(ar); // <---
                string text = Encoding.ASCII.GetString(_receive_buffer);
                Debug.Print("Server Received: " + text);                
            }
            catch (Exception e)
            {
                Debug.Print("Unexpected exception: " + e.Message);
            }
        }
