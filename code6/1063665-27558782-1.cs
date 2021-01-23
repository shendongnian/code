    int firstNumber;
    int secondNumber;
    string name = string.Empty;
    
    do
    {
        Console.Clear();
        Console.Write("What is your name?");
        name = Console.ReadLine();        
    } while (string.IsNullOrEmpty(name));
    Console.WriteLine("Hello {0}", name);
                
    do
    {
        // This will happen if the user types something that's not a number
        Console.Clear();
        Console.WriteLine("Hello {0}", name);
        Console.Write("Please enter the first number:");
    } 
    while (!int.TryParse(Console.ReadLine(), out firstNumber));
    
    do
    {
        // This will happen if the user types something that's not a number
        Console.Clear();
        Console.WriteLine("Hello {0}", name);
        Console.WriteLine("First number is: " + firstNumber);
        Console.Write("Please enter the second number:");
    }
    while (!int.TryParse(Console.ReadLine(), out secondNumber));
    
    Console.WriteLine("Second number is: " + secondNumber);
    Console.Read();
