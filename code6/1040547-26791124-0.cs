    private static int[] GetIntArrayFromUser(int numberOfElementsToGet)
    {
        var intArrayFromUser = new int[numberOfElementsToGet];
        for (int i = 0; i < numberOfElementsToGet; i++)
        {
            while (true)
            {
                // Prompt user for integer and get their response
                Console.Write("Enter an integer for item #{0}: ", i + 1);
                var input = Console.ReadLine();
                // Check the response with int.TryParse. 
                // If it's a valid int, break the while loop
                int tmpInt;
                if (int.TryParse(input, out tmpInt))
                {
                    intArrayFromUser[i] = tmpInt;
                    break;
                }
                // If we get here, we didn't break the while loop, so the input is invalid.
                Console.WriteLine("{0} is not a valid integer. Try again.", input);
            }
        }
        return intArrayFromUser;
    }
