    static void Main(string[] args)
    {
        var set = Enumerable.Range(1, 10000000)
                            .Select(i => new MyClass {Value = i, IsValid = i%2 == 0})
                            .ToList();
        Func<MyClass, int> select = i => i.IsValid ? i.Value : 0;
        Console.WriteLine(
            Sum(                        // Cost: N additions
                Select(set, select)));  // Cost: N delegate
        // Total cost: N * (delegate + addition) = Nd + Na
        Func<MyClass, bool> where = i => i.IsValid;
        Func<MyClass, int> wSelect = i => i.Value;
        Console.WriteLine(
            Sum(                        // Cost: M additions
                Select(                 // Cost: M delegate
                    Where(set, where),  // Cost: N delegate
                    wSelect)));
        // Total cost: N * delegate + M * (delegate + addition) = Nd + Md + Ma
    }
    // Cost: N delegate calls
    static IEnumerable<T> Where<T>(IEnumerable<T> set, Func<T, bool> predicate)
    {
        foreach (var mc in set)
        {
            if (predicate(mc))
            {
                yield return mc;
            }
        }
    }
    // Cost: N delegate calls
    static IEnumerable<int> Select<T>(IEnumerable<T> set, Func<T, int> selector)
    {
        foreach (var mc in set)
        {
            yield return selector(mc);
        }
    }
    // Cost: N additions
    static int Sum(IEnumerable<int> set)
    {
        unchecked
        {
            var sum = 0;
            foreach (var i in set)
            {
                sum += i;
            }
            return sum;
        }
    }
