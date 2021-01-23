    Console.WriteLine("Please, enter your age");
    string age = Console.ReadLine();
    Console.WriteLine("\nIn 10 years you will be:");
    DateTime myNewAge = new DateTime(int.Parse(age));
    Console.WriteLine(int.Parse(age) + 10);
