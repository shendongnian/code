    Console.Writeline("Enter the number of numbers to add: ");
    //Yes, I know you should actually do validation here
    var numOfNumbersToAdd = int.Parse(Console.Readline());
    int value;
    int[] arrayValues = new int[numOfNumbersToAdd];
    for(int i = 0; i < numOfNumbersToAdd; i++)
    {
        Console.Writeline("Please enter a value: ");
        var isValidValue = int.TryParse(Console.Readline(), out value);
        while(!isValidValue)
        {
            Console.WriteLine("Invalid value, please try again: ");
            isValidValue = int.TryParse(Console.Readline(), out value);
        }
        arrayValues[i] = value;
    }
    var sum = 0;
    foreach(var v in arrayValues)
    {
        sum += v;
    }
    Console.Writeline("Sum {0}", sum);
