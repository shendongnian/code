		static void Main(string[] args)
		{
			int digit = 0;
			const int LIMIT = 10;
			const int COLS = 3;
			int[] row = new int[LIMIT];
			for (int i = 0; i < row.Length; i++)
			{
				Console.WriteLine("Geef getal nummer " + (i + 1) + " in: ");
				// Re-try until user insert a valid integer.
				while (!int.TryParse(Console.ReadLine(), out digit))
					Console.WriteLine("Wrong format: please insert an integer number:");
				row[i] = digit;
			}
			PrintArray(row, COLS);
			// Wait to see console output.
			Console.ReadKey();
		}
		/// <summary>
		/// Print an array on console formatted in a number of columns.
		/// </summary>
		/// <param name="array">Input Array</param>
		/// <param name="columns">Number of columns</param>
		/// <returns>True on success, otherwise false.</returns>
		static bool PrintArray(int[] array, int columns)
		{
			if (array == null || columns <= 0)
				return false;
			if (array.Length == 0)
				return true;
			// Build a buffer of columns elements.
			string buffer = array[0].ToString();
			for (int i = 1; i < array.Length; ++i)
			{
				if (i % columns == 0)
				{
					Console.WriteLine(buffer);
					buffer = array[i].ToString();
				}
				else
					buffer += "\t" + array[i].ToString();
			}
			
			// Print the remaining elements
			if (array.Length % columns != 0)
				Console.WriteLine(buffer);
			
			return true;
		}
