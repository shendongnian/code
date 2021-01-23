    static void Main(string[] args)
    {
        int num1 = 0;
        int lowestNumber = 2147483647;//Max int value:)
        int secondLowest = 2147483647;        
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
                {
                    secondLowest = lowestNumber;
                    lowestNumber = num1;
                }
                else if (num1 < secondLowest && num1 > -1)
                    secondLowest = num1;
            }
        }
        Console.WriteLine(lowestNumber);
        Console.Read();
    }
