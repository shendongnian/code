    public static IEnumerable<List<T>> SplitList<T>(List<T> list, int numberOfRanges)
    {
        int sizeOfRanges = list.Count / numberOfRanges;
        int remainder = list.Count % numberOfRanges;
        int startIndex = 0;
        for (int i = 0; i < numberOfRanges; i++)
        {
            int size = sizeOfRanges + (remainder > 0 ? 1 : 0);
            yield return list.GetRange(startIndex, size);
            if (remainder > 0)
            {
                remainder--;
            }
            startIndex += size;
        }
    }
    static void Main()
    {
        List<int> list = Enumerable.Range(0, 10).ToList();
        IEnumerable<List<int>> result = SplitList(list, 3);
        foreach (List<int> values in result)
        {
            string s = string.Join(", ", values);
            Console.WriteLine("{{ {0} }}", s);
        }
    }
