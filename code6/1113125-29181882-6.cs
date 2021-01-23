        public void FileSendCyle(IAsyncResult ar)
        {
            if(ar.IsCompleted)
            {
                if(sendertc.Connected)
                {
                    int  read = senderfilestream.EndRead(ar);
                    if(read > 0)
                    {
                        sendertc.GetStream().BeginWrite(filesendbuffer,0,read,FileSendCyle2,null);
                    }
                    else
                    {
                        
                        sendertc.GetStream().Write(toByte("@FileEnd@",256),0,256);
                        
                    }
                }
            }
        }
