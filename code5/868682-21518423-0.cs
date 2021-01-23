    var names = new List<string>();
    var isps = new List<string>();
    string yourName; string yourIsp;
    Console.WriteLine("Enter your full name:");
    for (int i = 0; i < 4; i++)
        names.Add(Console.ReadLine());
    Console.WriteLine("Enter your ISP:");
    for (int j = 0; j < 4; j++)
        isps.Add(Console.ReadLine());
    foreach (var sentence in names.Zip(isps, (name, isp) => string.Format("Hello {0}, your email address is {1}", name, string.Concat(name, "@", isp).ToLower())))
        Console.WriteLine(sentence);
