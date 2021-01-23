	IPAddress start = IPAddress.Parse("192.168.1.1");
	var bytes = start.GetAddressBytes();
	var leastSigByte= start.GetAddressBytes().Last();
	var range=255 - leastSigByte;
	
	var pingReplyTasks = Enumerable.Range(leastSigByte,range).Select(x=>{
		var p = new Ping();
		bytes[3] = (byte)x;
		var destIp = new IPAddress(bytes);
		return p.SendPingAsync(destIp);
	}).ToList();
	
	await Task.WhenAll(pingReplyTasks);
	
	foreach(var pr in pingReplyTasks)
	{
		Console.WriteLine(pr.Result.Status);
	}
