    string eingabe = Console.ReadLine();
    int anzahlMinen = 0;
    if (!Int32.TryParse(eingabe, out anzahlMinen))
        Console.WriteLine("Dies ist keine gültige Zahl!");
    else if (anzahlMinen < 0 || anzahlMinen > 24)
        Console.WriteLine("Anzahl Minen muss zwischen 0 und 24 liegen!");
