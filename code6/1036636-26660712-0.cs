    public static void Main()
    {
        var currentNumber = 0;
        for (var i = 1; i <= 12; i++)
        {
            Console.Write(" Type in {0} number: ", i);
            var number = Console.ReadLine();
            int result;
            if (int.TryParse(number, out result))
            {
                if (currentNumber < result)
                {
                    currentNumber = result;
                }   
            }
        }
        Console.WriteLine("The highest number is {0}", currentNumber);
        Console.ReadKey();
    }
