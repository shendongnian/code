    /// <summary>
    /// Gets the rooted path to use to access the host.
    /// Returns an empty string if the server is unavailable.
    /// </summary>
    /// <param name="serverName">The server to connect to.</param>
    public static string GetNetworkPathFromServerName(string serverName)
    {
    	// Assume we can't connect to the server to start with.
    	var networkPath = String.Empty;
    
    	// If this is a rooted path, just make sure it is available.
    	if (Path.IsPathRooted(serverName))
    	{
    		// If the path exists, use it.
    		if (Directory.Exists(serverName))
    			networkPath = serverName;
    	}
    		// Else this is a network path.
    	else
    	{
    		// If the server name has a backslash in it, remove the backslash and everything after it.
    		serverName = serverName.Trim(@"\".ToCharArray());
    		if (serverName.Contains(@"\"))
    			serverName = serverName.Remove(serverName.IndexOf(@"\", StringComparison.Ordinal));
    
    		try
    		{
    			// If the server is available, format the network path properly to use it.
    			if (Dns.GetHostEntry(serverName) != null)
    			{
    				// Root the path as a network path (i.e. add \\ to the front of it).
    				networkPath = String.Format("\\\\{0}", serverName);
    			}
    		}
    		// Eat any Host Not Found exceptions for if we can't connect to the server.
    		catch (System.Net.Sockets.SocketException)
    		{ }
    	}
    
    	return networkPath;
    }
