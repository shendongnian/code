	[JsonObject(MemberSerialization.OptIn)]
	public class Test
	{    
		[JsonProperty]
		int x = 1;
	
		[JsonProperty]
		static int y = 2;
		
		[JsonProperty]
		const int z = 333;
	}
