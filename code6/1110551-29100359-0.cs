    var list = Enumerable.Range(1, 10).ToList(); // 1 , 2, 3, ..., 9, 10
    // For each odd number in the list, add that number * 100 to the list.
    for (int i = 0, n = list.Count; i < n ; ++i)
    {
        if ((list[i] & 1) != 0)      // Number is Odd?
            list.Add(list[i] * 100); // Append 100*number
    }
    foreach (int n in list)
        Console.WriteLine(n);
