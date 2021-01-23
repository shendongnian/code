	foreach (var item in items)
	{
		var fromIp = item.From.GetAddressBytes();
		var toIp = item.To.GetAddressBytes();
		Console.WriteLine("From {0} to {1}", item.From.ToString(), item.To.ToString());
		
		foreach (byte secondPart in Enumerable.Range(fromIp[1], toIp[1] - fromIp[1] + 1))
		{
			foreach (byte thirdPart in Enumerable.Range(fromIp[2], toIp[2] - fromIp[2] + 1))
			{
				var ip = new IPAddress(new byte[] {fromIp[0], secondPart, thirdPart, fromIp[3]});
				yield return string.Format("{0}\t{1}\t{2}\t{2}", item.C1, item.C2, ip.ToString());
			}
		}
	}
