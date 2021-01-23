	// Ask what you have to ask before the loop
	Console.Write("Enter the name: \n");
	string result = Console.ReadLine();
	while(true) 
	{
		Console.Write("Are you sure " + result + " is the right name? (y/n)\n");
		string test = Console.ReadLine();
		Console.Write("\n");
		if (test.ToLower() == "y")
		{
			// it will exit the loop
			break;
		}
		// when loop is not exited, keep asking until user answers with "y"
		Console.Write("What is your name then?\n");
		result = Console.ReadLine();
		Console.Write("\n");
	};
	
	// result will always contain the latest input, as it's not possible for the user to leave
	// except closing the application
	return result;
