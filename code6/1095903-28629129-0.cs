	void static Main()
	{
		List<  System.Threading.Tasks.Task> ts = new List<  System.Threading.Tasks.Task>();
	
		for(int i = 0; i < 20; i++)
		{
			var  num = Convert.ToUInt16(52000 + i);
			var t = new   System.Threading.Tasks.Task(() =>
			{
				UdpPortListener(num);
			});
	
	
			ts.Add(t);
		}
	
		ts.ForEach((x) => x.Start());
	}
	
	// Define other methods and classes here
	
	private static void UdpPortListener(UInt16 Port)
	{
		Console.WriteLine("Listening to port: {0}", Port);
	}
