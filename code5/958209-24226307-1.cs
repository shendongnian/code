    List<int> l1 = new List<int> { 1, 2, 3, 3, 4, 5 };
    List<string> l2 = new List<string> { "Z", "z", "z" };
    List<int> l3 = new List<int> { 8, 2, 3, 4 };
    List<int> l4 = new List<int> { 8, 4, 4, 3, 2 };
    Console.WriteLine(l1.GetOrdering()); // returns Ascending
    Console.WriteLine(l2.GetOrdering())); // return Ascending
    Console.WriteLine(l2.GetOrdering(StringComparer.InvariantCultureIgnoreCase))); // returns Constant
    Console.WriteLine(l3.GetOrdering())); // return Unordered
    Console.WriteLine(l4.GetOrdering())); // return Descending
