    var block = new ActionBlock<string>(
        async ip => 
        { 
            try
            {
                var host = (await Dns.GetHostEntryAsync(ip)).HostName;
                if (!string.IsNullOrWhitespace(host))
                {
                    hosts[ip] = host;
                }
            }
            catch
            {
                return;
            }
        },
        new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 5000});
