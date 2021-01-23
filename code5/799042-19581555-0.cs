    int[] arr = new int[10];
    for (int a = 0; a < 10; )
    {
        // Get number from user
        Console.Write("Enter number: ");
        string entered = Console.ReadLine();
        int val;
        // check for valid integer entered
        if (!Int32.TryParse(entered, out val))
            Console.WriteLine("Invalid number '{0}'", entered);
        // check number in allowed range
        else if (val < 10 || val > 100)
            Console.WriteLine("Value '{0}' out of allowed range (10-100)", val);
        // check number not already supplied
        else if (a > 0 && arr.Take(a).Contains(val))
            Console.WriteLine("Value '{0}' already entered");
        // add to array
        else
        {
            arr[a++] = val;
            Console.WriteLine("Added value '{0}'.  {1} remaining.", val, 10 - a);
        }
    }
