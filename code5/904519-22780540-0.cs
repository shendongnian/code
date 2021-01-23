        int HeaderLength = 2;
        int bodyLength;
        int bytesReceived;
        int totalBytesReceived;
        protected void StartListening()
        {
            StateObject state = new StateObject() { ProcessHeader = true };
            state.PrepareBuffer(HeaderLength);
            lock (_secureConnection)
                _secureConnection.BeginReceive(state.Buffer, 0, HeaderLength, 0, new AsyncCallback(ReadCallback), state);
        }
        /// <summary>
        /// Reads the callback.
        /// 
        /// A message is in this form:
        /// 
        /// 2 bytes indicate the leght of body message (n)
        /// n bytes for body message
        /// 
        /// </summary>
        /// <param name="ar">IAsyncResult.</param>
        private void ReadCallback(IAsyncResult ar)
        {
            if (_disposing)
                return;
            StateObject state = (StateObject)ar.AsyncState;
            try
            {
                lock (_secureConnection)
                    bytesReceived = _secureConnection.EndReceive(ar);
                if (state.ProcessHeader)    //In this phase I receive 2 bytes that indicate the total length of the next message
                {
                    state.ProcessHeader = !state.ProcessHeader;
                    bodyLength = GetBodyLength(state.Buffer);   //I interpret 2 bytes to know body message length
                    state.CompleteMessage.AddRange(state.Buffer);
                    state.PrepareBuffer(bodyLength);
                    totalBytesReceived = bytesReceived = 0;
                    lock (_secureConnection)
                        _secureConnection.BeginReceive(state.Buffer, 0, bodyLength, 0, new AsyncCallback(ReadCallback), state);
                }
                else    //In this phase I receive the message, with one or more recursive CallBack
                {
                    state.CompleteMessage.AddRange(state.Buffer.ToList().GetRange(0, bytesReceived));
                    
                    totalBytesReceived += bytesReceived;
                    int totalBytesMissing = bodyLength - totalBytesReceived;
                    
                    if (totalBytesReceived < bodyLength)
                    {
                        state.PrepareBuffer(totalBytesMissing);
                        lock (_secureConnection)
                            _secureConnection.BeginReceive(state.Buffer, 0, totalBytesMissing, 0, new AsyncCallback(ReadCallback), state);
                        return;
                    }
                    //totalMessageLenght = body length plus first 2 bytes indicate body length
                    int totalMessageLenght = bodyLength + 2;    
                    var completeMessage = state.CompleteMessage.GetRange(0, totalMessageLenght).ToList();
                    ProcessMessage(completeMessage);
                    state.ProcessHeader = !state.ProcessHeader; //I prepare Callback to read 2 bytes indicate the total length of the next message
                    state.CompleteMessage.Clear();
                    state.PrepareBuffer(HeaderLength);
                    lock (_secureConnection)
                        _secureConnection.BeginReceive(state.Buffer, 0, HeaderLength, 0, new AsyncCallback(ReadCallback), state);
                }
            }
            catch (Exception e)
            {
                Close(true);
            }
        }
