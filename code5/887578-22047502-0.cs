    //define this outside
    TcpClient ClientList;
    
    //....
    	if (Main && List && Admin)
    	{
    		Console.WriteLine("[SERVER]" + "Waiting to connect");
    		bw.RunWorkerAsync();
    		
    		NextCode();
    	}
    
    }
    
    private void NextCode()
    {
    	//CODE
    }
    
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
    	ClientList = ListServer.AcceptTcpClient();
    }
    
    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    	if (ClientList.Connected)
    	{
    		Console.ForegroundColor = ConsoleColor.Green;
    		Console.WriteLine(ListMessage + "CONECTED !");
    	}
    }
