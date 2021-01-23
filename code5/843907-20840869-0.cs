        public class TcpSender
        {
            Mutex moveToInternal = new Mutex();
            
            List<Message> internalMessages = new List<Message>();
            List<Message> externalMessages = new List<Message>();
            String status = "stopped";
            public void TcpSenderThreadStart()
            {
                status = "started";
                while(status == "started")
                {
                    Boolean didSomething = false;
                    //pickup new messages and move to internal buffer
                    if (externalMessages.Count>0)
                    {
                        didSomething = true;
                        if (moveToInternal.WaitOne())
                        {
                            internalMessages.AddRange(externalMessages);
                            externalMessages.Clear();
                            moveToInternal.ReleaseMutex();
                        }
                    }
                    //deliver messages
                    for (int i = 0; i < internalMessages.Count;i++)
                    {
                        //send request
                        Byte[] data = System.Text.Encoding.ASCII.GetBytes(internalMessages[i].GetMessage());
                        NetworkStream stream = internalMessages[i].GetClient().GetStream();
                        stream.Write(data, 0, data.Length);
                    }
                    internalMessages.Clear();
                    if(!didSomething) Thread.Sleep(1); //Nothing to receive or send, maybe tomorr... next milisec there is something to do
                }
            }
            public void TcpSenderThreadStop()
            {
                status = "stopped";
            }
            public String GetStatus()
            {
                return status;
            }
            //return true if message was accepted
            public Boolean addMessageNonBlocking(TcpClient client, String message)
            {
                Boolean gotMutex = moveToInternal.WaitOne(0);
                {
                    Message tmpMessage = new Message(client, message);
                    externalMessages.Add(tmpMessage);
                    moveToInternal.ReleaseMutex();
                }
                return gotMutex;
            }
            public void addMessageBlocking(TcpClient client, String message)
            {
                //loop until message is delivered
                while (!addMessageNonBlocking(client, message))
                {
                    Thread.Sleep(1); //could skip this, but no need for busy waiting
                }
            }
            private class Message
            {
                TcpClient client;
                String message;
                public Message(TcpClient client, String message)
                {
                    this.client = client;
                    this.message = message;
                }
                public TcpClient GetClient()
                {
                    return client;
                }
                public String GetMessage()
                {
                    return message;
                }
            }
        }
