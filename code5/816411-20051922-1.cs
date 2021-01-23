    void SomeMethod()
    {
        int i = 0;
        Func<string> inc = () => (i++).ToString();
        inc();
        inc();
        Console.WriteLine(i); // 2
    }
