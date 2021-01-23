        public void FileConnect(IAsyncResult ar)
        {
            if(ar.IsCompleted)
            {
                sender.EndConnect(ar);
                if(sender.Connected)
                {
                    sender.GetStream().Write(toByte(filesendcommand,256),0,256);
                    sender.GetStream().BeginRead(ComputerNameBuffer,0,256,FileSendCyleStarter,null);
                    
                }
            }
        }
