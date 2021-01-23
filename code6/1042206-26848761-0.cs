    int userInput;
    bool isNumber = int.Tryparse(usernumber, out userInput);
    if( isNumber && userInput < randomNumber)
    {
      Console.WriteLine("No");
    }
    else if(!isNumber)
    {
      Console.WriteLine("Please enter a valid integer");
    }
