    static void Main(string[] args)
    {
        int num1 = 0;
        int lowestNumber = 2147483647;//Max int value:)
        for (int i = -1; i < 10; i++)
        {
            Console.Write("   ");
            num1 = int.Parse(Console.ReadLine());
            if (num1 < -1)
            {
                Console.WriteLine("You entered a number less than -1, please enter higher number");
                Console.Write("   ");
            }
            
            else
            {
                if (num1 < lowestNumber && num1 > -1)
                    lowestNumber = num1;
            }
        }
        Console.WriteLine(lowestNumber);
        Console.Read();
    }
