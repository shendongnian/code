    string RelDstring;
    int RelD;
    bool ifintreld;
    
    RelDstring = Console.ReadLine();
    ifintreld = int.TryParse(RelDstring, out RelD);
    while(!ifintreld)
    {
        Console.WriteLine("Podano bledny rok wydania, uzyj liczb calkowitych.");
        RelDstring = Console.ReadLine();
        ifintreld = int.TryParse(RelDstring, out RelD);
    }
