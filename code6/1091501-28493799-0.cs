    IEnumerable<Class1> c1 = GetStudents();
    string text = Console.ReadLine();
    int value;
    while (!Int32.TryParse(text, out value))
    {
        Console.WriteLine("ID Was not a Valid ID Number. Try Again");
        text = Console.ReadLine();
    }    
    bool exist = c1.Any(s = > s.IdNum == value);
