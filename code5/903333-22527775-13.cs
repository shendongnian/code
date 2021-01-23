    var input = new AInput();
    var response = GetResponse(input);
    
    if(response is XOutput)
    {
        Console.WriteLine("Input was {0} and output was {1}", input.GetType().Name, response.GetType().Name);
    } else if (response is YOutput)
    {
        Console.WriteLine("Input was {0} and output was {1}", input.GetType().Name, response.GetType().Name);
    }
