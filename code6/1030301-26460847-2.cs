    static void Main(string[] args)
    {
        string[] letters = { "d", "c", "a", "b" };
        // Use LINQ query syntax to sort the array alphabetically.
        var sorted = from letter in letters
                        orderby letter
                        select letter;
        // Loop with the foreach keyword.
        foreach (string value in sorted)
        {
            Console.WriteLine(value);
        }
        foreach (string val in letters.OrderBy(letter => letter))
        {
            Console.WriteLine(val);
        }
    }
