    public void ServerAcceptEnd(IAsyncResult ar)
    {
        if(!ar.IsCompleted)
        {
            //Something went wrong
            AcceptServer();
            return;
        }
        try
        {
            var cli = servertc.EndAcceptTcpClient(ar);
            if(cli.Connected)
            {
                //Get the first Command   
                cli.GetStream().BeginRead(serverredbuffer,0,serverredbuffer.Length,ServerFirstReadEnd,cli);
            }
            else
            {
                //Connection was not successfull log and wait
                AcceptServer();
            }
        }
        catch(Exceiption ex)
        {
            //An error occur log and wait for new connections
            AcceptServer();
        }
     }
