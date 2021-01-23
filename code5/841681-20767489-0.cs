    static void Main(string[] args)
    {
        int min = int.MaxValue;
        Console.WriteLine("\n Number of values:");
        int num = Convert.ToInt32(Console.ReadLine());
        var enteredValue = 0;
        for (var i = 0; i < num; i++)
        {
            Console.WriteLine("\n Enter value:");
            enteredValue = Convert.ToInt32(Console.ReadLine());
            if (min>enteredValue) min = enteredValue;
        }
        Console.WriteLine("Smallest is {0}", min);
        Console.ReadLine();
    }
