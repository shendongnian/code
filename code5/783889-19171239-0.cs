    static void Main(string[] args)
    {
        string numberIn;
        int numberOut;
        while (true) 
        {
            numberIn = Console.ReadLine();
            if (int.TryParse(numberIn, out numberOut))
            {
                if (numberOut < 0)
                {
                    Console.WriteLine("Invalid. Enter a number that's 0 or higher.");
                }
                else
                {
                    break; // if not less than 0.. break out of the loop.
                }
            }    
        }
        Console.WriteLine("Success! Press any key to exit");
        Console.Read();
    }
