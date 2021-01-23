    static void Main(string[] args)
    {
        int sum = 0;
        while (true)
        {
            Console.WriteLine("Enter a Number: ");
            var line = Console.ReadLine();
            int n;
            if (int.TryParse(line, out n))
            {
                if (n == 0) 
                    break;
                sum += n;
            }
        }
        Console.WriteLine("The sum is: " + sum);
    }
