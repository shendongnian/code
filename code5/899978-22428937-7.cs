    static int len = 1;
    static void Main()
    {
        if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
        {
            var len = 3.14;
            Console.WriteLine(len);
        }
        Console.WriteLine(len); // error CS0135: 'len' conflicts with the declaration 'csutils.Program.len'
    }
