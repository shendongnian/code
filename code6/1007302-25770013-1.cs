    public Task CheckConnectionAsync()
    {
        return Task.Run(() =>
        {
            try
            {
                 IPAddress = DnsManager.GetIPAddress(Name + "." + CurrentConfig.DomainName);
                 ... // check availability by IP rather than name...
            }
            // catch stuff here...
        });
    }
