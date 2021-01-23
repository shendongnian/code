    static void Main(string[] args)
        {
            int[] arr = new int[10]; // The size of the array is 10
            int input;
            int savedNumCount = 0;
            const int MIN = 10;  // Use constant to set the range instead
            const int MAX = 100; // of typing them in code
            Console.WriteLine("Please enter 10 numbers between 10 and 100. They cannot be identical.");
            do
            {
                if (int.TryParse(Console.ReadLine(), out input) == false)
                { // Check if number is entered
                    Console.WriteLine("Please enter a number.");
                    continue;
                }
                if (input < MIN || input > MAX)
                { // Check range
                    Console.WriteLine("The number you entered does not fall between 10 and 100.\r\n Please try again.");
                    continue;
                }                
                if (savedNumCount == 0)
                { // Compare with existing numbers
                    arr[savedNumCount] = input; // No checking for 1st input
                    savedNumCount++;
                }
                else
                {
                    if (!arr.Contains(input))
                    {
                        arr[savedNumCount] = input;
                        savedNumCount++;
                    }
                    else
                    {
                        Console.WriteLine("The number you entered is identical to one of the other numbers. Please try again");
                    }
                }
            }
            while (savedNumCount < arr.Length);
            string result = "The numbers you entered were ";
            foreach (int num in arr)
                result += num.ToString() + "  ";
            Console.WriteLine(result);
            Console.WriteLine("Please press enter to continue");
            Console.ReadKey();
        }
