    for (int i = 0; i < 4; i++) {
        Console.WriteLine("Enter your full name:");
        string yourName =Console.ReadLine();
        Console.WriteLine("Enter your ISP:");
        string yourIsp = Console.ReadLine();
        char[] separator = {' '};
        string[] yourWords;
        yourWords = yourName.Split(separator);
        string yourFirstName = yourWords[0];
        string yourLastName = yourWords[1];
        string yourEmailAddress = yourFirstName + yourLastName + "@" + yourIsp;
        yourEmailAddress = yourEmailAddress.ToLower();
        Console.WriteLine("Hello {0}, your email address is {1}", yourName, yourEmailAddress);
    }
