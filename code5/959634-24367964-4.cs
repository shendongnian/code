    protected bool IsAutomation()
    {
        // In your case, I'd config-drive your desktop user agent strings
    	if (!string.IsNullOrEmpty(Properties.Settings.Default.BasicAuthenticationUserAgents))
    	{
    		string[] agents = Properties.Settings.Default.BasicAuthenticationUserAgents.Split(';');
    		foreach (string agent in agents)
    			if (Context.Request.Headers["User-Agent"].Contains(agent)) return true;
    	}
    	return false;
    }
