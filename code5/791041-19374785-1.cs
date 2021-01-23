        // Cached Socket object that will be used by each call for the lifetime of this class
        Socket _socket = null;
        // Signaling object used to notify when an asynchronous operation is completed
        static ManualResetEvent _clientDone = new ManualResetEvent(false);
        // Define a timeout in milliseconds for each asynchronous call. If a response is not received within this
        // timeout period, the call is aborted.
        const int TIMEOUT_MILLISECONDS = 5000;
        // The maximum size of the data buffer to use with the asynchronous socket methods
        const int MAX_BUFFER_SIZE = 2048;
        /// <summary>
        /// SocketClient Constructor
        /// </summary>
        public SocketClient()
        {
            // The following creates a socket with the following properties:
            // AddressFamily.InterNetwork - the socket will use the IP version 4 addressing scheme to resolve an address
            // SocketType.Dgram - a socket that supports datagram (message) packets
            // PrototcolType.Udp - the User Datagram Protocol (UDP)
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }
        /// <summary>
        /// Send the given data to the server using the established connection
        /// </summary>
        /// <param name="serverName">The name of the server</param>
        /// <param name="portNumber">The number of the port over which to send the data</param>
        /// <param name="data">The data to send to the server</param>
        /// <returns>The result of the Send request</returns>
        public string Send(string serverName, int portNumber, string data)
        {
            string response = "Operation Timeout";
            // We are re-using the _socket object that was initialized in the Connect method
            if (_socket != null)
            {
                // Create SocketAsyncEventArgs context object
                SocketAsyncEventArgs socketEventArg = new SocketAsyncEventArgs();
                // Set properties on context object
                socketEventArg.RemoteEndPoint = new DnsEndPoint(serverName, portNumber);
                // Inline event handler for the Completed event.
                // Note: This event handler was implemented inline in order to make this method self-contained.
                socketEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(delegate(object s, SocketAsyncEventArgs e)
                {
                    response = e.SocketError.ToString();
                    // Unblock the UI thread
                    _clientDone.Set();
                });
                // Add the data to be sent into the buffer
                byte[] payload = Encoding.UTF8.GetBytes(data);
                socketEventArg.SetBuffer(payload, 0, payload.Length);
                // Sets the state of the event to nonsignaled, causing threads to block
                _clientDone.Reset();
                // Make an asynchronous Send request over the socket
                _socket.SendToAsync(socketEventArg);
                // Block the UI thread for a maximum of TIMEOUT_MILLISECONDS milliseconds.
                // If no response comes back within this time then proceed
                _clientDone.WaitOne(TIMEOUT_MILLISECONDS);
            }
            else
            {
                response = "Socket is not initialized";
            }
            return response;
        }
