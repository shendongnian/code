    static void Main(string[] args)
    {
        int sum = 0;
        while (true)
        {
            Console.WriteLine("Enter a Number: ");
            int n;
            if (int.TryParse(Console.ReadLine(), out n))
            {
                if (n == 0) 
                    break;
                sum += n;
            }
        }
        Console.WriteLine("The sum is: " + sum);
    }
