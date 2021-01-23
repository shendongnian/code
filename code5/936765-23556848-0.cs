    public static List<String> GetInput()
    {
        //declared variables
        string userInput;
        List<String> userInputs = new List<String>();
    
        Console.Write("Enter your name: ");
        userInput= Console.ReadLine();
        userInputs.Add(userInput);
    
        Console.Write("Enter your age: ");
        userInput = Console.ReadLine();
        userInputs.Add(userInput);
    
        Console.Write("Enter the Gas Mileage: ");
        userInput = Console.ReadLine();
        userInputs.Add(userInput);
    
        return userInput;
    }
