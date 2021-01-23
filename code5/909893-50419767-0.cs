    public PingCheck(string address, int timeout = 250, int pingNbr = 1)
    {
    	var rtn = IPAddress.TryParse(address, out IPAddress addr);
    	if (rtn)
    	{
    		IpAddress = addr;
    		
    		var dataSend = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    		var pinger = new Ping();
    		var pingerOptions = new PingOptions();
    		pingerOptions.DontFragment = true;
    		var buffer = Encoding.ASCII.GetBytes(dataSend);
    		
    		var statusList = new List<IPStatus>();
    		var lossList = new List<bool>();
    		var tripList = new List<long>();
    		
    		for (int i=0; i<pingNbr; i++)
    		{
    			var pingerReply = pinger.Send(addr, timeout, buffer, pingerOptions);
    			var bufback = pingerReply.Buffer;
    			var dataBack = Encoding.ASCII.GetString(bufback);
    		
    			var status = pingerReply.Status;
    			var loss = (dataSend != dataBack);
    			var msecs = pingerReply.RoundtripTime;
    		
    			statusList.Add(status);
    			lossList.Add(loss);
    			tripList.Add(msecs);
    		}
           // TODO: Add statistics check
    	}
    	else
    		throw new PingException("No IP Address");
    }
