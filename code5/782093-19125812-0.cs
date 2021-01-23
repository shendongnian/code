    /// <summary>
    /// Gets the rooted initial directory to use to access the host.
    /// Returns an empty string if the server is unavailable.
    /// </summary>
    /// <param name="serverName">The server to connect to.</param>
    private static string GetInitialDirectoryFromServerName(string serverName)
    {
    	// Assume we can't connect to the server to start with.
    	var initialDirectory = string.Empty;
    
    	// If this is a rooted path, just make sure it is available.
    	if (Path.IsPathRooted(serverName))
    	{
    		// If the path doesn't exist, reset it.
    		if (Directory.Exists(serverName))
    			initialDirectory = serverName;
    	}
    	// Else this is a network path.
    	else
    	{
    		// If the server name has a backslash in it, remove the backslash and everything after it (e.g. SQL001\Test should just be SQL001).
    		serverName = serverName.Trim(@"\".ToCharArray());
    		if (serverName.Contains(@"\"))
    			serverName = serverName.Remove(serverName.IndexOf(@"\", System.StringComparison.Ordinal));
    
    		try
    		{
    			// If the server is available, format the Initial Directory properly to use it.
    			if (System.Net.Dns.GetHostEntry(serverName) != null)
    			{
    				// Root the path as a network path (i.e. add \\ to the front of it).
    				initialDirectory = string.Format("\\\\{0}", serverName);
    			}
    		}
    		// Eat any Host Not Found exceptions for if we can't connect to the server.
    		catch (System.Net.Sockets.SocketException e)
    		{ }
    	}
    
    	return initialDirectory;
    }
