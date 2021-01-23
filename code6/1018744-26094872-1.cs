    IEnumerable<int> sequence = Enumerable.Range(0, 15);
    Func<int, bool> predicate = x => x != 10;
    var result = 
        sequence.SkipWhile(predicate)
        .Concat(sequence.TakeWhile(predicate));
    // This prints
    // 10, 11, 12, 13, 14, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            
    Console.WriteLine(string.Join(", ", result));
