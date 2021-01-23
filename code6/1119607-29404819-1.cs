    public static void Main(params string[] args)
    {
        // Note: this is not an idiomatic way to instantiate sorted lists.
        var h1 = new SortedList<string, int>() { 
            { "one", 1 }, 
            { "two", 2 }
        };
        var h2 = new SortedList<string, int>() { 
            { "three", 3 }, // because "three" < "two"
            { "two", 22 }
        };
        var h3 = MergeSortedLists(h1, h2);
        Console.WriteLine(string.Join(", ", h3.Select(e => string.Format("{{{0}, {1}}}", e.Key, e.Value))));
        // Outputs:
        // {one, 1}, {three, 3}, {two, 2}
    }
