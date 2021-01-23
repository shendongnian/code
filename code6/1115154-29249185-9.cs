	private static string GetInput(string Prompt)
	{
		string Result = "";
		do {
			Console.Write(Prompt + ": ");
			Result = Console.ReadLine();
			if (string.IsNullOrEmpty(Result)) {
				Console.WriteLine("Empty input, please try again");
			}
		} while (!(!string.IsNullOrEmpty(Result)));
		return Result;
	}
