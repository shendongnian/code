	public static class StringRandomize
	{
		static readonly Random rnd = new Random();
		static char[] permmitedCharacters { get; set; }
		static StringRandomize()
		{
			List<char> Chars=  new List<char>();
			for (int i = 48; i < 48+10; i++)
			{
				Chars.Add((char)i);
			}
			for (int i = 65; i < 65+26; i++)
			{
				Chars.Add((char)i);
			}
			permmitedCharacters = Chars.ToArray();
		}
		public static string Randomize(string input, double RandomizePercent = 30)
		{
			StringBuilder result = new StringBuilder();
			int index = 0;
			while (index < input.Length)
			{
				
				if (rnd.Next(0, 100) <= RandomizePercent)
				{
					if (rnd.Next(0, 100) <= RandomizePercent)
					{
						result.Append(GenerateCaracter());
					}
					else
					{
						if (rnd.Next(0, 100) > 50)
						{
							result.Append(input.ToLower()[index]);
						}
						else
						{
							result.Append(input.ToUpper()[index]);
						}
						index++;
					}
				}
				else
				{
					result.Append(input[index]);
					index++;
				}
			}
			return result.ToString();
		}
		private static char GenerateCaracter()
		{
			return permmitedCharacters[rnd.Next(0, permmitedCharacters.Length)];
		}
	}
	
		private static void GenerateRandomDirectories(string path, int value)
		{
			//I'm supposing value is the number of lines that you want
			var lines = File.ReadAllLines(@"M:\\dictionar.txt");
			Random rnd = new Random();
			if (path != null && Directory.Exists(path))
			{
				for (int i = 0; i < value; i++)
				{
					Directory.CreateDirectory(path + "\\" + StringRandomize.Randomize(lines[rnd.Next(0,lines.Length)]));
				}
			}
		}
