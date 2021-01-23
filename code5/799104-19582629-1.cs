    //...
    bool Auswahl = false;
    string Geschlecht;
    do
    {
        Console.Write("Geschlecht (m/w):");
        Geschlecht = Console.ReadLine();
        switch(Geschlecht)
        {
            case "m":
                Auswahl = true;
                break;
            case "w":
                Auswahl = true;
                break;
            default:
                Console.WriteLine("Ungültige Eingabe");
                Console.WriteLine("(m)ännlich/(w)eiblich");
                break;
        }
    }while (Geschlecht != "m" && Geschlecht != "w");
        
    if (Auswahl != false) {Console.WriteLine("Eingabe wird verarbeitet");}
    //etc...
