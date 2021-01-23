    string str = @"Hewlett Packard LaserJet Printer Thingy
    Sony LaserJet Printer Thingy";
    string result = Regex.Replace(str, @"(?m)^(Hewlett Packard\s*|[A-Z][a-z]+\s*)", "");
    Console.WriteLine(result);
    Console.ReadLine();
