    while (input != "")
    {
        Console.WriteLine("Please enter another integer: ");
        input = Console.ReadLine();
        int value;
        if(!int.TryParse(input, out value))
        {
           // Error
        }
        else
        {
           numbersInput.Add(value);
        }
    }
