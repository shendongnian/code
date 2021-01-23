    private void RunTest(object o, EventArgs e)
    {
    	BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
    	
    	worker.RunWorkerCompleted += TestComplete;
    	worker.DoWork += TestConnection;
    	
    	p.Visible = true;
    	
    	worker.RunWorkerAsync(new Tuple<string, string>(address.Text, port.Text));
    }
    
    private void TestConnection(object sender, DoWorkEventArgs e)
    {
    	bool success = false;
    	var connection = e.Argument as Tuple<string, string>;
    	
    	if (null != socket)
    	{
    		socket.Close();
    	}
    	
    	Thread.Sleep(1000);
    	
    	IPEndPoint myEndpoint = new IPEndPoint(0, 0);
      	IPHostEntry remoteMachineInfo = Dns.GetHostEntry(connection.Item1);
      	IPEndPoint serverEndpoint = new IPEndPoint(remoteMachineInfo.AddressList[0],
          int.Parse(connection.Item2));
    	  
    	socket = new Socket(myEndpoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    	
    	try
    	{
    		socket.Connect(serverEndpoint);
    		success = true;
    	}
    	catch
    	{
    		success = false;
    	}
    	
    	e.Result = success;
    }
    
    // Define other methods and classes here
    private void TestComplete(object sender, RunWorkerCompletedEventArgs e)
    {
    	if (e.Error == null)
    	{
    		var success = (bool)e.Result;
    		if (success)
    		{
    			p.Image = global::BlockingUI.Properties.Resources.accept;
    		}
    		else
    		{
    			p.Image = global::BlockingUI.Properties.Resources.stopper;
    		}
    	}
    	else
    	{
    		//unexpected error, show message or whatever
    	}
    }
