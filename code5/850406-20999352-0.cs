    // State object for receiving data from remote device.
    public class StateObject
    {
        /// <summary>
        /// Client socket.
        /// </summary>
        public Socket workSocket = null;
        
        /// <summary>
        /// Size of receive buffer.
        /// </summary>
        public const int BufferSize = 256;
        
        /// <summary>
        /// Receive buffer.
        /// </summary>
        public byte[] buffer = new byte[BufferSize];
        
        /// <summary>
        /// Received data string.
        /// </summary>
        public StringBuilder sb = new StringBuilder();
    }
    public class AsynchronousClient
    {
        // The port number for the remote device.
        private const int _port = xxxx;
        private const string _address = "xx.xx.xx.xx";
        // ManualResetEvent instances signal completion.
        private static ManualResetEvent _connectDone = new ManualResetEvent(false);
        private static ManualResetEvent _sendDone = new ManualResetEvent(false);
        private static ManualResetEvent _receiveDone = new ManualResetEvent(false);
        private static string _response = string.Empty;
        public static void StartClient(string data)
        {
            // Connect to a remote device.
            try
            {
                var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // Connect to the remote endpoint.
                client.BeginConnect(_address, _port, ConnectCallback, client);
                _connectDone.WaitOne();
                // Send test data to the remote device.
                //Console.WriteLine("Sending data : {0}", data);
                Send(client, "US\r\n");
                _sendDone.WaitOne();
                Thread.Sleep(1000);
                Send(client, data);
                _sendDone.WaitOne();
                // Receive the response from the remote device.                
                Receive(client);
                _receiveDone.WaitOne();
                // Write the response to the console.
                //Console.WriteLine("Response received : {0}", _response);
                // Release the socket.
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                var client = (Socket)ar.AsyncState;
                // Complete the connection.
                client.EndConnect(ar);
                Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());
                // Signal that the connection has been made.
                _connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private static void Receive(Socket client)
        {
            try
            {
                // Create the state object.
                var state = new StateObject();
                state.workSocket = client;
                // Begin receiving the data from the remote device.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, ReceiveCallback, state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                var state = (StateObject)ar.AsyncState;
                var client = state.workSocket;
                
                int bytesRead = client.EndReceive(ar);
                if (bytesRead > 0)
                {
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, ReceiveCallback, state);
                }
                else
                {
                    // All the data has arrived; put it in response.
                    if (state.sb.Length > 1) _response = state.sb.ToString();                    
                    _receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private static void Send(Socket client, String data)
        {            
            var byteData = Encoding.ASCII.GetBytes(data);
            client.BeginSend(byteData, 0, byteData.Length, 0, SendCallback, client);
        }
        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                var client = (Socket)ar.AsyncState;
                var bytesSent = client.EndSend(ar);                
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);                
                _sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
