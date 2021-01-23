    const int MINRANGE = 1;
    const int MAXRANGE = 20;
    int input = 0;
    
    Console.Write("Enter the desired maximum: ");
    
    string strInput = Console.ReadLine();
    
    Console.WriteLine("\n\n\n");
    if (input > MAXRANGE || input < MINRANGE)
    {
        Console.WriteLine("That is not a valid value, please try again.");
    }
    else
    {
            for (int.TryParse(strInput, out input); input >= MINRANGE && input <= 
            MAXRANGE; input--)
             {
    
               Console.WriteLine("{0,2}   {1,3}", input, Math.Pow(input, 3));
    
             }
    }
