        public void ServerReadFileCyle(IAsyncResult ar)
        {
            TcpClient cli = (TcpClient)ar.AsyncState;
            if(ar.IsCompleted)
            {
                int read = cli.GetStream().EndRead(ar);
                if(read == 256)
                {
                    try
                    {
                        string res = toString(serverreceivebuffer);
                        if(res == "@FileEnd@")
                            read = 0;
                    }
                    catch
                    {
                    }
                }
                if(read > 0)
                {
                    serverfile.Write(serverreceivebuffer,0,read);
                    cli.GetStream().BeginRead(serverreceivebuffer,0,1024,ServerReadFileCyle,cli);
                }
                else
                {
                    serverfile.Flush();
                    serverfile.Dispose();
                    AcceptServer();
                }
            }
        }
