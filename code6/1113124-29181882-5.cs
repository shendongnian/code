        public void FileSendCyleStarter(IAsyncResult ar)
        {
            if(ar.IsCompleted)
            {
                if(sender.Connected)
                {
                    string kabul = toString(ComputerNameBuffer);
                    if(kabul == "@FileAccepted@")
                    {
                        senderfilestream.BeginRead(filesendbuffer,0,1024,FileSendCyle,null);
                    }
                }
            }
        }
