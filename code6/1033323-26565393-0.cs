    static void Main(string[] args)
        {
            int value = 0;
            while(value < 1)
            {
                Console.WriteLine("Enter a positive integer:");
                string line = Console.ReadLine(); // Read string from console
                
                if (int.TryParse(line, out value) && value <= 0)
                {
                    Console.WriteLine("Input is not a positive integer. Try again");
                }
            }
            Console.WriteLine("Value=" + value);
            Console.ReadKey();
        }
