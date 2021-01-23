    string a1 = "TE";
    string a2 = "ST";
    string a = a1 + a2;
    if (string.IsInterned(a) != null)
        Console.WriteLine("a was interned");
    else
        Console.WriteLine("a was not interned");
    string.Intern(a);
    if (string.IsInterned(a) != null)
        Console.WriteLine("a was interned");
    else
        Console.WriteLine("a was not interned");
