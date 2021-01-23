    public static void Connect(List<IPAddress> ipAddresses) 
    {
        var listeners = new List<Socket>();
	    var tasks = new List<Task<Socket>>();
	
	    foreach (var ipAddress in ipAddresses)
    	{
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
	    	listeners.Add(listener);        
            listener.Bind(localEndPoint);
            listener.Listen(100);	
		
    		tasks.Add(AcceptTaskAsync(listener));
    	}   
	
    	Task.WaitAll(tasks.ToArray());
    }
    public static async Task<Socket> AcceptTaskAsync(Socket listener)
    {
        return await Task<Socket>.Factory.FromAsync(listener.BeginAccept, listener.EndAccept, TaskCreationOptions.DenyChildAttach);
    }
