    Console.WriteLine("Enter your name: ");
    string s = Console.ReadLine();
    byte[] chars = Encoding.UTF8.GetBytes(s);
    bool hasnonletters = false;
    for (int x = 0; x < chars.Length; x++)
    {
        Console.Write(".");
        int ascii = (int)chars[x];
        if (!((ascii > 64 && ascii < 91) || (ascii > 96 && ascii < 123)))
        {
            hasnonletters = true;
            break;
        }
    }
    
    if (hasnonletters)
    {
        Console.WriteLine("{0} has Non-letters!", s);
    }
    else
    {
        Console.WriteLine("{0} is all letters!", s);
    }
    
    Console.ReadKey();
