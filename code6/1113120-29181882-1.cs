        public void ServerFirstReadEnd(IAsyncResult ar)
        {
        if(!ar.IsCompleted)
        {
            //Something went wrong
            AcceptServer();
            return;
        }
            try
            {
                TcpClient cli = (TcpClient)ar.AsyncState;
                int read = cli.GetStream().EndRead(ar);
                string req = toString(serverredbuffer);  
                if(req.StartsWith("@File@"))
                {
                    //File Received
                    string filename = req.Replace("@File@","");
                    string[] spp = filename.Split(';');
                    filename = spp[0];
                    serverreceivetotalbytes = Convert.ToInt64(spp[1]);
                    cli.GetStream().Write(toByte("@FileAccepted@",256),0,256);
                    cli.GetStream().BeginRead(serverreceivebuffer,0,1024,ServerReadFileCyle,cli)   
                }
                else
                {
                    //Message Received
                }
            }
            catch(Exception ex)
            {
                //An error occur log and wait for new connections
                AcceptServer();
            }
        }
