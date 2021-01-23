    Console.WriteLine("Start by typing 'hello'");
	String activity = Console.ReadLine();
	
    activity = activity.Trim().ToLower(); // try adding this line
	if ("hello".Equals(activity))
		Console.WriteLine("Hi!");
	else
	{
		Console.WriteLine("Please try again.");
		WakeUp();
	}
