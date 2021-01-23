    // Create a List of integers, the size is not needed
    List<int> arr = new List<int>();
    int count = 0;
    // Not sure if now you require to double the size of the array
    while (count < quantity)             
    {
        string line = Console.ReadLine();
        int inputNumber;
        if(Int32.TryParse(line, inputNumber))
        {
            // Add the input to the list....
            arr.Add(inputNumber);
            count++;
        }
        else
        {
            Console.WriteLine("An integer number is required!");
        }
     }
