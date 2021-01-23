    while (true)
    {
        Console.WriteLine("1. Cofee 2. Jam. 3. Bread 4. Apple");
        String a = Console.ReadLine();
        int price = 0;
        switch (a)
        {
            case "1": price += 2; break;
            case "2": price += 3; break;
            case "3": price += 4; break;
            case "4": price += 5; break;
            default: continue;
        }
        Console.WriteLine("your selected item is {0} Your price is ${1} Do You Want to Continue? YES or NO", a, price);
        String max = Console.ReadLine();
        max = max.ToUpper();
        if (max == "NO")
            break;
    }
