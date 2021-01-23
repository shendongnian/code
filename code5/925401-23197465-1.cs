    // Do not use Console.Read, but ReadLine to wait the end of input from your user
    string userInput Console.ReadLine();          
    // Convert to a number using Int32.TryParse to check if your user really types a number
    // and not something that will raise an exception if it is not a number
    int quantity;
    if(!Int32.TryParse(userInput, out quantity))
    {
        Console.WriteLine("An integer number is required!");
        return;
    }
    // Dimension you array basing its size on the number passed
    int[] arr = new int[quantity * 2];               
    int count = 0;
    
    while (count < quantity*2)             
    {
        string line = Console.ReadLine();
        int inputNumber;
        // Again to convert to a number, use Int32.TryParse 
        if(Int32.TryParse(line, inputNumber))
        {
            arr[count] = inputNumber;
            count++;
        }
        else
        {
            Console.WriteLine("An integer number is required!");
        }
     }
