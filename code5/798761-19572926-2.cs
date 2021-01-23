    public static void Main()
    {
        Console.WriteLine("Please enter number");
        int input;
        while (!int.TryParse(Console.ReadLine(), out input) || input <= 0)
        {
            Console.WriteLine("You have enter an invald option");
            Console.WriteLine("Please enter number");
        }
        Console.Write("Factorial of " + input + " is : ");
         
        int output = 1;
        for (int i = input; i > 0; i--)
        {
            Console.Write((i == input) ? i.ToString() : "*" + i);
            output *= i;
        }
        Console.Write(" = " +output);
        Console.ReadLine();
    }
