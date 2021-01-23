	static T ReadInput<T>(string prompt)
	{
		return ReadInput<T>(prompt, CultureInfo.CurrentCulture);
	}
	static T ReadInput<T>(string prompt, IFormatProvider formatProvider)
	{
		bool validInput = false;
		T result = default(T);
		Console.WriteLine("Prompt");
		while (!validInput)
		{
			try
			{
				result = (T)Convert.ChangeType(Console.ReadLine(), typeof (T), formatProvider);
				validInput = true;
			}
			catch
			{
				Console.WriteLine("Could not interpret value, please try again.");
			}
		}
		return result;
	}
