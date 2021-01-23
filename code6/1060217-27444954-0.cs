	string pattern = @"[(]?(\d{3})[)]?[ -.]?(\d{3})[ -.]?(\d{4})";
    System.Console.WriteLine("What is your phone number?");
    string phoneNumber = Console.ReadLine();
    while (!Regex.IsMatch(phoneNumber, pattern))
    {
        Console.WriteLine("Bad Input");
        phoneNumber = Console.ReadLine();
    }
    var match = Regex.Match(phoneNumber, pattern);
    if (match.Groups.Count == 4)
	{
	 	System.Console.WriteLine("Number matched : "+match.Groups[0].Value);
    	System.Console.WriteLine(match.Groups[1].Value + "-" + match.Groups[1].Value + "-" + match.Groups[2].Value);
	}
