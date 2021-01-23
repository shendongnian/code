    for (int i = 0; i < 10; i++)
        Console.WriteLine(i.ToString());
    if (str == "hello")
        Console.WriteLine("hello back!");
    using (SecureString s = new SecureString())
        Console.WriteLine("Here we have s");
    Console.WriteLine("but here it's out of scope already");
