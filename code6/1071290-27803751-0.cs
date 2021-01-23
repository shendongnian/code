    public static int GetBoundedIntFromUser(int minVal, int maxVal)
    {
        if (minVal >= maxVal)
        {
            throw new ArgumentException("minVal must be less than maxVal.");
        }
        int input;
        while (true)
        {
            Console.Write("Please enter a number from {0} to {1}: ", minVal, maxVal);
            if (int.TryParse(Console.ReadLine(), out input)
                && input >= minVal && input <= maxVal)
            {
                break;
            }
            Console.WriteLine("That input is not valid. Please try again.");
        }
        return input;
    }
