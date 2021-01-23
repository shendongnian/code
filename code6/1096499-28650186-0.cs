    Console.WriteLine("Please, enter your age");
    string age = Console.ReadLine();
    
    DateTime myNewAge = DateTime.Today.AddYears(-int.Parse(age) - 10);
    Console.WriteLine(myNewAge);
