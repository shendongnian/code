    string[, ] Arr = new string[4, 5]
		{
		{
		"1A", " 2A", " 3A", " 4A", " 5A"
		}
		, {
		"1B", " 2B", " 3B", " 4B", " 5B"
		}
		, {
		"1C", " 2C", " 3C", " 4C", " 5C"
		}
		, {
		"1D", " 2D", " 3D", " 4D", " 5D"
		}
		};
		Console.WriteLine("List of seats.");
		Console.WriteLine();
		var fullyBooked = false;
		for (int i = 0; i < Arr.GetLength(0); i++)
		{
			for (int k = 0; k < Arr.GetLength(1); k++)
			{
				Console.Write(Arr[i, k]);
				fullyBooked = Arr[i, k] == "X" ? true : false;
			}
			Console.WriteLine();
		}
		if (!fullyBooked)
		{
			Console.WriteLine("Enter your seat: ");
			string textToReplace = Console.ReadLine();
			for (int i = 0; i < Arr.GetLength(0); i++)
			{
				for (int k = 0; k < Arr.GetLength(1); k++)
				{
					if (Arr[i, k] == textToReplace)
					{
						Arr[i, k] = " X ";
					}
				}
			}
			for (int i = 0; i < Arr.GetLength(0); i++)
			{
				for (int k = 0; k < Arr.GetLength(1); k++)
				{
					Console.Write(Arr[i, k]);
				}
				Console.WriteLine();
			}
		}
		else
		{
			Console.WriteLine("Fully Booked ");
		}
