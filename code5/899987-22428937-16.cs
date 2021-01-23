    static int len = 1;
    static void Main()
    {
        Console.WriteLine(len);
        if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
        {
            var len = 3.14;  // error CS0136: A local variable named 'len' cannot be declared in this scope because it would give a different meaning to 'len', which is already used in a 'parent or current' scope to denote something else
            Console.WriteLine(len);
        }
    }
