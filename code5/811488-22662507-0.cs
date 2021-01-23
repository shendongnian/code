     ....
         var res = sock .BeginAccept(AcceptCallback, null);
     
        }
        private void AcceptCallback(IAsyncResult result)
        {           
            Socket socket = sock .EndAccept(result);           
            while (true)
            {
                sock.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, 
                                  new AsyncCallback(ReceiveCallBack), socket);
                _resetEvent.WaitOne();
                _resetEvent.Reset();
            }
        }
        ....
