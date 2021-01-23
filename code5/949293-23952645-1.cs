    var block = new ActionBlock<string>(
        ip => 
        { 
            try
            {
                var host = (await Dns.GetHostEntryAsync(ip)).HostName;
                if (!host.IsNullOrWhitespace())
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
