	string UserName = "";
	do {
		Console.Write("Username: ");
		UserName = Console.ReadLine();
		if (!string.IsNullOrEmpty(UserName)) {
			Console.WriteLine("OK");
		} else {
			Console.WriteLine("Empty input, please try again");
		}
	} while (!(!string.IsNullOrEmpty(UserName)));
