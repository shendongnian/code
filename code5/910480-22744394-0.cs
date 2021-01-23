    string userInput = Console.ReadLine();
    int parsedValue;
    if(!Int32.TryParse(userInput, out parsedValue))
    {
        // Decide what to do here, parsing failed!
    }
    else
    {
        // String format from user was valid and parsed value is in parsedValue variable.
    }
    
