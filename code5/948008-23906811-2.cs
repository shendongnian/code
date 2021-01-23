		static void Main(string[] args)
		{
			int digit = 0;
			const int LIMIT = 100;
			const int COLS = 3;
			int[] row = new int[LIMIT];
			for (int i = 0; i < row.Length; i++)
			{
				Console.WriteLine("Geef getal nummer " + (i + 1) + " in: ");
				digit = int.Parse(Console.ReadLine());
				row[i] = digit;
			}
			if (row.Length < 1)
				return;
			string buffer = row[0].ToString();
			for (int i = 1; i < row.Length; ++i)
			{
				if (i % COLS == 0)
				{
					Console.WriteLine(buffer);
					buffer = row[i].ToString();
				}
				else
					buffer += "\t" + row[i].ToString();
			}
			Console.WriteLine(buffer);
		}
