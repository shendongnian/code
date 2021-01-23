	// Get the current Site Name
	var siteName = HostingEnvironment.SiteName;
	// Get the sites section from the AppPool.config
	var sitesSection = WebConfigurationManager.GetSection(null, null, "system.applicationHost/sites");
	var site = sitesSection.GetCollection().Where(x => string.Equals((string)x["name"], siteName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
	if (site != null)
	{
		foreach (var iisBinding in site.GetCollection("bindings"))
		{
			var protocol = iisBinding["protocol"] as string;
			var bindingInfo = iisBinding["bindingInformation"] as string;
			string[] parts = bindingInfo.Split(':');
			if (parts.Length == 3)
			{
				//string ip = parts[0]; // May be "*" or the actual IP
				//string port = parts[1]; // Always a port number (even if default port)
				string hostHeader = parts[2]; // May be a host header or "". This will only be the domain name if you keep it in sync with the DNS.
				// Use the hostHeader as the domain name
			}
		}
	}
