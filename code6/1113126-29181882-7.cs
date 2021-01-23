        public void FileSendCyle2(IAsyncResult ar)
        {
            if(ar.IsCompleted)
            {
                if(sendertc.Connected)
                {
                   sendertc.GetStream().EndWrite(ar);
                   senderfilestream.BeginRead(filesendbuffer,0,1024,FileSendCyle,null);
                }
            }
        }
