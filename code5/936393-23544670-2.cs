    public static IEnumerable<T[]> BuildCombinations<T>(T[] items, int itemsCountInCombination, int startIndex = 0)
    {
        if (itemsCountInCombination == 0)
        {
            yield return new T[0];
            yield break;
        }
        for (int i = startIndex; i < items.Length; i++)
        {
            foreach (var combination in BuildCombinations(items, itemsCountInCombination - 1, i))
            {
                var c = new T[itemsCountInCombination];
                c[0] = items[i];
                Array.Copy(combination, 0, c, 1, combination.Length);
                yield return c;
            }
        }
    }
    private static void Main(string[] args)
    {
        foreach (var c in BuildCombinations(Enum.GetValues(typeof (OrderedColors)).Cast<OrderedColors>().Reverse().ToArray(), 6))
        {
            foreach (var color in c)
            {
                Console.Write(color);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
