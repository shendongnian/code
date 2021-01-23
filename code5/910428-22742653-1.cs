    // declare random instance outside of the method 
    // because we don't want duplicate numbers
    static Random rnd = new Random();
    public static int GenerateRandomNumber()
    {
        // declare variables to store range of number
        int from, to;
        // use while(true) and force user to enter valid numbers
        while(true)
        {
            // we use TryParse in order to avoid FormatException and validate the input
            bool a = int.TryParse(Console.ReadLine(), out from);
            bool b = int.TryParse(Console.ReadLine(), out to);
             
            // check values and ensure that 'to' is greater than 'from'
            // otherwise we will get a ArgumentOutOfRangeException on rnd.Next
            
            if(a && b && from < to) break; // if condition satisfies break the loop
            
            // otherwise display a message and ask for input again
            else Console.WriteLine("You have entered invalid numbers, please try again.");
        }
        // generate a random number and return it
        return rnd.Next(from, to + 1);
    }
