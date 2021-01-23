	void Main()
	{
		var exclusions = new HashSet<byte> { 1, 200, 58, 11, 66, 9 };
		
		var results = RandomBytes()
						.Where(b => exclusions.Contains(b) == false)
						.Take(50)
						.ToArray();
	}
	
	public IEnumerable<byte> RandomBytes()
	{
		var random = new Random();
		byte[] buffer = new byte[32];
		while(true)
		{
			random.NextBytes(buffer);
			foreach(var ret in buffer)
			{
				yield return ret;
			}
		}
	}
