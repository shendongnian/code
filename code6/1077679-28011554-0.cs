        class MessagePacket
        {
            private byte[] data;
            private int length;
            public MessagePacket(int len, byte[] aData)
            {
                this.length = len;
                data = new byte[len];
                Array.Copy(aData, data, len);
            }
            public int Length()
            {
                return this.length;
            }
            public byte[] Data()
            {
                return this.data;
            }
        }
        static Queue<MessagePacket> MsgQueue = new Queue<MessagePacket>();
        static Mutex mutQueue = new Mutex();
        /// <summary> 
        ///     This thread read the message from the sever and put them in the queue.
        /// </summary>
        static void readSocket()
        {
            byte[] dataSize = new byte[4];
            while (true/*or ApplicationIsActive*/)
            {
                try
                {
                    // it's assumed that data is a 32bit integer in network byte order
                    if (ClientSocket.Receive(dataSize, 4, SocketFlags.None) != 4)
                    {
                        return;
                    }
                    int size = BitConverter.ToInt32(dataSize, 0);
                    size = IPAddress.NetworkToHostOrder(size);
                    byte[] buffer = new byte[size];
                    int offset = 0;
                    while (size > 0)
                    {
                        int ret = ClientSocket.Receive(buffer, offset, size, SocketFlags.None);
                        if (ret <= 0)
                        {
                            // Socket has been closed or there is an error, quit
                            return;
                        }
                        size -= ret;
                        offset += ret;
                    }
                    mutQueue.WaitOne();
                    try { MsgQueue.Enqueue(new MessagePacket(size, buffer)); }
                    finally { mutQueue.ReleaseMutex(); }
                }
                catch  
                {
                    return;
                }
            }
        }
        /// <summary> 
        ///     This thread processes the messages in the queue.
        /// </summary>
        static void processMessages()
        {
            while (true/*or ApplicationIsActive*/)
            {
                if (MsgQueue.Count > 0)
                {
                    MessagePacket msg;
                    mutQueue.WaitOne();
                    try { msg = MsgQueue.Dequeue(); }
                    finally { mutQueue.ReleaseMutex(); }
                    // Process the message: msg
                }
                else Thread.Sleep(50);
            }
        }
