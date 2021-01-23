    class Client
    {
        private byte[] buffer = new byte[256];
        private Socket socket;
        private NetworkStream networkStream;
        private AsyncCallback callbackRead;
        private AsyncCallback callbackWrite;
        public Client(Socket clientSocket)
        {
            socket = clientSocket;
            networkStream = new NetworkStream(clientSocket);
            callbackRead = new AsyncCallback(OnReadComplete);
            callbackWrite = new AsyncCallback(OnWriteComplete);
        }
        public void StartRead()
        {
            networkStream.BeginRead(buffer, 0, buffer.Length, callbackRead, null);
        }
        private void OnReadComplete(IAsyncResult ar)
        {
            int bytesRead = networkStream.EndRead(ar);
            if (bytesRead > 0)
            {
                string s = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesRead);
                //do something with complete data here
                networkStream.BeginWrite(buffer, 0, bytesRead, callbackWrite, null);
            }
            else
            {
                networkStream.Close();
                socket.Close();
                networkStream = null;
                socket = null;
            }
        }
        private void OnWriteComplete(IAsyncResult ar)
        {
            networkStream.EndWrite(ar);
            networkStream.BeginRead(buffer, 0, buffer.Length, callbackRead, null);
        }
    }
