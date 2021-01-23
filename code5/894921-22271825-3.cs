    static void Main(string[] args)
    {
        int num1 = 0;
        List<int> numbers = new List<int>();
        for (int i = -1; i < 10; i++)
        {
            Console.Write("   ");
            if (num1 < -1)
            {
                Console.WriteLine("You entered a number less than -1, please enter higher number");
                Console.Write("   ");
                i--;
            }
    
            else
            {
                num1 = int.Parse(Console.ReadLine());
                numbers.Add(num1);
            }
        }
         //sorting
        numbers.Sort(); 
        int amountCounted = 0;
        for (int i = 0; i < numbers.Count && amountCounted < 5; i++)
        {
            if (numbers[i] > -1)
            {
                Console.WriteLine(numbers[i]);
                amountCounted++;
            }
            else
                i++;
        }
        Console.Read();
    }
