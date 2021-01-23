    for (int x = 0; x < input.Length; x++)
        int inputnumber = input[x]; // This is new
        if (inputnumber <= random[x])
        {
            Console.WriteLine("The entered number " + inputnumber + " is less than " + random[x]);
        }
        else if (inputnumber >= random[x])
        {
            Console.WriteLine("The entered number " + inputnumber + " is greater than " + random[x]);
        }
        else if (inputnumber == random[x])
        {
            Console.WriteLine("The entered number " + inputnumber + "  is equal to " + random[x]);
        }
    }
