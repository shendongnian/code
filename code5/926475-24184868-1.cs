    /// <summary>
    /// Installs the transport agent by calling the corresponding PowerShell commands (Install-TransportAgent and Enable-TransportAgent).
    /// The priority of the agent is set to the highest one.
    /// You need to restart the MSExchangeTransport service after install.
    ///
    /// Throws ExchangeHelperException on error.
    /// </summary>
    public static void installTransportAgent()
    {
    	using (Runspace runspace = RunspaceFactory.CreateRunspace(getPSConnectionInfo()))
    	{
    
    		runspace.Open();
    		using (PowerShell powershell = PowerShell.Create())
    		{
    			powershell.Runspace = runspace;
    
    			int currPriority = 0;
    			Collection<PSObject> results;
    
    			if (!isAgentInstalled())
    			{
    				// Install-TransportAgent -Name "Exchange DkimSigner" -TransportAgentFactory "Exchange.DkimSigner.DkimSigningRoutingAgentFactory" -AssemblyPath "$EXDIR\ExchangeDkimSigner.dll"
    				powershell.AddCommand("Install-TransportAgent");
    				powershell.AddParameter("Name", AGENT_NAME);
    				powershell.AddParameter("TransportAgentFactory", "Exchange.DkimSigner.DkimSigningRoutingAgentFactory");
    				powershell.AddParameter("AssemblyPath", System.IO.Path.Combine(AGENT_DIR, "ExchangeDkimSigner.dll"));
    
    				results = invokePS(powershell, "Error installing Transport Agent");
    
    				if (results.Count == 1)
    				{
    					currPriority = Int32.Parse(results[0].Properties["Priority"].Value.ToString());
    				}
    
    				powershell.Commands.Clear();
    				
    				// Enable-TransportAgent -Identity "Exchange DkimSigner"
    				powershell.AddCommand("Enable-TransportAgent");
    				powershell.AddParameter("Identity", AGENT_NAME);
    
    				invokePS(powershell, "Error enabling Transport Agent");
    			}
    
    			powershell.Commands.Clear();
    			
    			// Determine current maximum priority
    			powershell.AddCommand("Get-TransportAgent");
    
    			results = invokePS(powershell, "Error getting list of Transport Agents");
    			
    			int maxPrio = 0;
    			foreach (PSObject result in results)
    			{
    				
    				if (!result.Properties["Identity"].Value.ToString().Equals(AGENT_NAME)){
    					maxPrio = Math.Max(maxPrio, Int32.Parse(result.Properties["Priority"].Value.ToString()));
    				}
    			}
    			
    			powershell.Commands.Clear();
    
    			if (currPriority != maxPrio + 1)
    			{
    				//Set-TransportAgent -Identity "Exchange DkimSigner" -Priority 3
    				powershell.AddCommand("Set-TransportAgent");
    				powershell.AddParameter("Identity", AGENT_NAME);
    				powershell.AddParameter("Priority", maxPrio + 1);
    				results = invokePS(powershell, "Error setting priority of Transport Agent");
    			}
    		}
    	}
    
    }
    
    /// <summary>
    /// Checks if the last powerShell command failed with errors.
    /// If yes, this method will throw an ExchangeHelperException to notify the callee.
    /// </summary>
    /// <param name="powerShell">PowerShell to check for errors</param>
    /// <param name="errorPrependMessage">String prepended to the exception message</param>
    private static Collection<PSObject> invokePS(PowerShell powerShell, string errorPrependMessage)
    {
    	Collection<PSObject> results = null;
    	try
    	{
    		results = powerShell.Invoke();
    	}
    	catch (System.Management.Automation.RemoteException e)
    	{
    		if (errorPrependMessage.Length > 0)
    			throw new ExchangeHelperException("Error getting list of Transport Agents:\n" + e.Message, e);
    		else
    			throw e;
    	}
    	if (powerShell.Streams.Error.Count > 0)
    	{
    		string errors = errorPrependMessage;
    		if (errorPrependMessage.Length > 0 && !errorPrependMessage.EndsWith(":"))
    			errors += ":";
    
    		foreach (ErrorRecord error in powerShell.Streams.Error)
    		{
    			if (errors.Length > 0)
    				errors += "\n";
    			errors += error.ToString();
    		}
    		throw new ExchangeHelperException(errors);
    	}
    	return results;
    }
    	
	
