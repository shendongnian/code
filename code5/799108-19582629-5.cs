    //...
    Console.Write("Geschlecht (m/w):");
    string Geschlecht = Console.ReadLine();
    while (Geschlecht != "m" && Geschlecht != "w");
    {
        Console.WriteLine("Ungültige Eingabe");
        Console.WriteLine("(m)ännlich/(w)eiblich");
        Console.Write("Geschlecht (m/w):");
        Geschlecht = Console.ReadLine();
    }
    Console.WriteLine("Eingabe wird verarbeitet");
    //etc...
