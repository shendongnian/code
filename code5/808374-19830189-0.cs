	static bool enteredNumber()
	{
		int intValue;
		double doubleValue;
		Console.Write("Enter a number: ");
		string input = Console.ReadLine();
		return Int32.TryParse(input, out intValue) ? true : double.TryParse(input, out doubleValue);
	}
