	class Program
	{
		static void Main(string[] args)
		{
			string filename = "example.txt";
			Dictionary<string, int[][]> myDictionary = new Dictionary<string, int[][]>();
			BuildMyDataDictionary(filename, myDictionary);
			//lookup via key
			int x = 20;
			int y = 180;
			string key = string.Format("{0}.{1}", x, y);
			int[][] values = myDictionary[key];
			//print the values to check
			foreach (int[] array in values)
				foreach (int i in array)
					Console.Write(i + ", ");
			Console.WriteLine();
			Console.ReadKey();
		}
		private static void BuildMyDataDictionary(string filename, Dictionary<string, int[][]> myDictionary)
		{
			StreamReader r = new StreamReader(filename);
			string line = r.ReadLine();
			// read through the file line by line and build the dictionary
			while (line != null)
			{
				Regex regx = new Regex(@"//\s*H\-(\d*)\w(\d*)");
				Match m = regx.Match(line);
				if (m.Success)
				{
					// make a key of the two parts int 1 and int2 separated by a "."
					string key = string.Format("{0}.{1}", m.Groups[1], m.Groups[2]);
					// continue reading the block
					List<int[]> intList = new List<int[]>();
					line = r.ReadLine();
					while (!Regex.IsMatch(line, @"^\s*\}"))
					{
						Regex regex = new Regex("[{},]");
						intList.Add(regex.Replace(line, " ").Trim().Split(new char[] { ' ' }).Select(int.Parse).ToArray());
						line = r.ReadLine();
					}
					myDictionary.Add(key, intList.ToArray());
				}
				line = r.ReadLine();
			}
		}
	}
