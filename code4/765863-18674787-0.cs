    public unsafe void Method()
    {
        int x = 10;
        int y = 20;
        int *ptr1 = &x;
        int *ptr2 = &y;
        Console.WriteLine((int)ptr1);
        Console.WriteLine((int)ptr2);
        Console.WriteLine(*ptr1);
        Console.WriteLine(*ptr2);
    }
