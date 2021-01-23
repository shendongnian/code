        /// <summary>
        /// Buffer where received bytes or bytes received are stored 
        /// </summary>
        private byte[] _byteBuffer = null;
        /// <summary>
        /// Callback result for reading data from the named pipe
        /// </summary>
        private IAsyncResult _pipeResult;
        /// <summary>
        /// Named object to send and receive data to and from watchdog
        /// </summary>
        NamedPipeClientStream _pipeClient;
        private object _pipeState = new object();
        private void StartClientNamedPipeListening()
        {
                _pipeClient = new NamedPipeClientStream(".", "testpipe",
                    PipeDirection.InOut, PipeOptions.Asynchronous,
                    TokenImpersonationLevel.Impersonation);
                // Reads the data coming in from the pipe and call the 
                // thread safe delegate to get the data received.
                _byteBuffer = new Byte[50];
                _pipeResult = _pipeClient.BeginRead(_byteBuffer, 0,
                    _byteBuffer.Length, PipeReadCallback, _pipeState);      
        }
       private void PipeReadCallback(IAsyncResult ar)
        {
            int bytesRead = 0;
            // if port serial is open and..
            if (_pipeClient.IsConnected)
            {
                // the stream can read then..
                if (_pipeClient.CanRead)
                {
                    // wait for asynchronous read to be completed
                    bytesRead = _pipeClient.EndRead(ar);
                }
            }
            if (bytesRead > 0)
            {
                StreamString ss = new StreamString(_pipeClient);
                // Validate the server's signature string 
                if (ss.ReadString() == "I am the one true server!")
                {
                    // The client security token is sent with the first write. 
                    // Send the name of the file whose contents are returned 
                    // by the server.
                    ss.WriteString(@"C:\Temp\namedpipestring.txt");
                    // Print the file to the screen.
                    Console.WriteLine(ss.ReadString(), false);
                }
                else
                {
                    Console.WriteLine("Server could not be verified.");
                }
                
                // Start waiting for the next watchdog message
                StartClientNamedPipeListening();
            }
        }
