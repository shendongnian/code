    bool ignoreAllFoos = true;
    foreach (Foo foo in fooCollection)
    {
        if (ignoreAllFoos)
        {
            continue;
        }
        Console.WriteLine(foo.Name);
    }
