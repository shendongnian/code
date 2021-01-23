    string a = Console.ReadLine();
    int num;
    if (int.TryParse(a, out num))
    {
        Console.WriteLine(a);
    }
    else
    {
        Console.WriteLine("-1");
    }
