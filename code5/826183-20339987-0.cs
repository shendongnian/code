    static void main()
    {
        try
        {
           Console.Write("Enter first operand: ");
           double a = readOperand(Console.ReadLine());
     
           Console.Write("Enter second operand: ");
           double b = readOperand(Console.ReadLine());
    
           // Do something with them
        }
       catch (FormatException)
       {
           Console.WriteLine("You didn't enter a floating point number.");
       }
    }
