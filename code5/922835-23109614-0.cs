    // send request
    foreach (string host in hosts)
    	pinger(host);
    
    // async function
    async void pinger(string host)
    {
    	var ping = new System.Net.NetworkInformation.Ping();
    	bool bResp;
    
    	try
    	{
    		var result = await ping.SendPingAsync(host, 4000);
    		bResp = result.Status == System.Net.NetworkInformation.IPStatus.Success;
    	}
    	catch { bResp = false; }
    
    	txt_result.Text += bResp.ToString() + Environment.NewLine;
    }
