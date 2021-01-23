    do
    {
        Console.WriteLine("Podano bledny rok wydania, uzyj liczb calkowitych.");
        RelDstring = Console.ReadLine();
    }
    while (int.TryParse(RelDstring, out RelD));
