    bool validated = false;
    int integerRequired;
    Console.WriteLine("Type an integer number:");
    while(validated == false)
    {    
        string userInput = Console.ReadLine();
        validated  = int.TryParse (userInput, out integerRequired);
        if (validated)
            validated = true;
        else
            Console.WriteLine("Not a valid integer, please retype a valid integer number");
    }
    float singleRequired;
    validated = false;
    Console.WriteLine("Type a floating point number:");
    while(validated == false)
    {    
        string userInput = Console.ReadLine();
        validated  = Single.TryParse (userInput, out singleRequired);
        if (validated)
            validated = true;
        else
            Console.WriteLine("Not a valid float, please retype a valid float number");
    }
