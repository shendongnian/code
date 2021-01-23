    public static void Main(string[] args)
    {
        // While "values" isn't a particularly descriptive name, it's better
        // than "t"
        int[] values = new int[30];
        // Limit the scope of i - declare it in the loop header
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = i / 6;
        }
        // You don't need the index here, so use a foreach loop. Generally prefer
        // foreach over for
        foreach (int value in values)
        {
            // You don't need any string concatenation here...
            Console.WriteLine(value);
        }
        Console.ReadKey(true);
    }
