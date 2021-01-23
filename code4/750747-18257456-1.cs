    Console.Writeline("Enter the number of numbers to add: ");
    //Yes, I know you should actually do validation here
    var numOfNumbersToAdd = int.Parse(Console.Readline());
    int value;
    int[] arrayValues = new int[numOfNumbersToAdd];
    for(int i = 0; i < numOfNumbersToAdd; i++)
    {
        Console.Writeline("Please enter a value: ");
        //Primed read
        var isValidValue = int.TryParse(Console.Readline(), out value);
        while(!isValidValue) //Loop until you get a value
        {
            Console.WriteLine("Invalid value, please try again: "); //Tell the user why they are entering a value again...
            isValidValue = int.TryParse(Console.Readline(), out value);
        }
        arrayValues[i] = value; //store the value in the array
    }
    //I would much rather do this with LINQ and Lists, but the question asked for arrays.
    var sum = 0;
    foreach(var v in arrayValues)
    {
        sum += v;
    }
    Console.Writeline("Sum {0}", sum);
