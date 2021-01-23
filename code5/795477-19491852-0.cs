    Regex reg = new Regex(@"^([0-2]?[0-9]|3[0-2])$");
    Console.WriteLine(reg.IsMatch("00"));
    Console.WriteLine(reg.IsMatch("22"));
    Console.WriteLine(reg.IsMatch("33"));
    Console.WriteLine(reg.IsMatch("42"));
