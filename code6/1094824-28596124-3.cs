    while (input != "")
    {
        Console.WriteLine("Please enter another integer: ");
        input = Console.ReadLine();
        numbersInput.Add(input);
    }
    
    if (input == "")
    {
        foreach (string value in numbersInput)
        {
            Console.WriteLine("The number that was added to the list is : " + " " + value);
        }
        Console.ReadLine();
    }
