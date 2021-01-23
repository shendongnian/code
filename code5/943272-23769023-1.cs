    string RelDstring;
    int RelD;
    Console.WriteLine("Podaj rok wydania");
    RelDstring = Console.ReadLine();        // copied from previous question
    bool ifintreld = int.TryParse(RelDstring, out RelD);
    while (ifintreld != true)
    {
        Console.WriteLine("Podano bledny rok wydania, uzyj liczb calkowitych.");
        RelDstring = Console.ReadLine();
        ifintreld = int.TryParse(RelDstring, out RelD);
    }
