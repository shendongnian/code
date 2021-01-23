    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine("Vnesete kluc");
        string kluc = Console.ReadLine();
        if (kluc.StartsWith("a"))
            kluc = "A" + kluc.Substring(1);
        Console.WriteLine("Vnesete podatok");
        string podatok = Console.ReadLine();
        hashtable.Add(kluc, podatok);
    }
