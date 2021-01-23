    int GetInteger(string prompt)
    {
        Console.WriteLine(prompt);
        while (true)
        {
            string s = Console.ReadLine();
            int value;
            if (int.TryParse(s, out value))
                return value;
            Console.WriteLine("Invalid input, try again!");
        }
    }
