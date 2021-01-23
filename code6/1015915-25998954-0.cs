	static void Main(string[] args)
	{	
		int rows = 4;
		int columns = 9;
	
		for (int i = 0; i < rows; i++)
		{		
            // Print a string with `i` spaces.
			Console.Write(new String(' ', i));
		
			int hashes = columns - ((i + 1) * 2) + 1;
			Console.Write(new String('#', hashes));
			Console.WriteLine();
		}
	}
	
	
