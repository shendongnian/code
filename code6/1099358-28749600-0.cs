	double number;
	string message;
	Console.WriteLine("Welcome and enter a number.");
	number = double.Parse(Console.ReadLine());
	if (number < 0)
	{
		message = "Your number is Negative";
	}
	else
	{
		message = "Your number is Positive";
	}
	Console.WriteLine(message);
	Console.ReadLine();
