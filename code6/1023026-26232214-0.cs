	public class C4
	{
		public int ISLTMT { get; set; }
		public int ISSSMMT { get; set; }
		public int ISLTMTS { get; set; }
		// ...
		public static C4 ParseFromLine(string line)
		{
			string[] values = line.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
			
			return new C4
			{
				ISLTMT = int.Parse(C4values[0]),
				ISSSMMT = int.Parse(C4values[1]),
				ISLTMTS = int.Parse(C4values[2]),
				// ...
			};
		}	
	}
