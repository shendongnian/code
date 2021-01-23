    Func<string, Task> checkProxyAsync = async(s) => {
        Ping ping = new Ping();
    
        try {
            string[] proxy = s.Split(':');
            lblLog.Text = "Testing Proxy: " + proxy[0];
            PingReply reply = await ping.SendAsync(proxy[0], Convert.ToInt32(proxy[1]));
    
            if(reply.Status == IPStatus.Success)
            {
                 workingProxies.Add(s);
                 lblSuccessProxies.Text = workingProxies.Count.ToString();
            }
            else
            {
                 failedProxies.Add(s);
                 lblFailedProxies.Text = failedProxies.Count.ToString();
            }
        } catch(Exception ex)
        {
            // DEBUG
            Console.WriteLine(ex);
        }
    };
