    static void Main()
    {
        // Change this if you want more or less space between inputs
        const int numberOfSpacesBetweenInputs = 1;
        Console.WriteLine("Enter 10 numbers and hit enter between each one:");
        // This list will hold valid numbers input by user
        var numbers = new List<int>();
        int temp;
        var inputLength = 0;
        while (numbers.Count < 10)
        {
            // Get input from the user
            var input = Console.ReadLine();
            // We keep track of the length of the user input, and add 
            // however many spaces we want between entries
            inputLength += input.Length + numberOfSpacesBetweenInputs;
            // If the input length is longer than the console buffer,
            // reset it so it wraps to the next line
            inputLength = inputLength % Console.BufferWidth;
            // Use TryParse, so we only add valid numbers.
            if (int.TryParse(input, out temp)) numbers.Add(temp);
            // Reset cursor position
            Console.SetCursorPosition(inputLength, Console.CursorTop - 1);
        }
        Console.WriteLine("\n\nThank you. The valid entries are:\n\n{0}", 
            string.Join(", ", numbers));
        Console.Write("\n\nPress any key to exit...");
        Console.ReadKey();
    }
