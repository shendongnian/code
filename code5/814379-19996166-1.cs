    Console.WriteLine("ISBN-Prüfziffer berechnen");
    Console.WriteLine("=========================");
    Console.WriteLine();
    Console.Write("ISBN-Nummer ohne Prüfziffer: ");
    string ISBNstring = Console.ReadLine();
    int sum = 0;
    for (int i = 0; i < 12; i++)
    {
        int digit = ISBNstring[i] - '0';
        if (i % 2 == 1)
        {
            digit *= 3;
        }
        sum += digit;
    }
    int result = 10 - (sum%10);
            
    Console.WriteLine(result);
    Console.ReadLine();
