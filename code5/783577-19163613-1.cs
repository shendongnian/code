    //var data = new[] {1, 1, 13, 2, 3, 4, 4, 5, 6, 7, 7, 8, 9, 10, 11, 11, 12, 13, 13, 13};
    var data = new[] {1, 1, 2, 3, 4, 4, 5, 6, 7, 7, 8, 9, 10, 11, 11, 12, 13, 13, 13};
    var largest = int.MinValue;
    var indices = new List<int>();
    foreach (var x in data.Select((value, idx) => new {value, idx}))
    {
        if (x.value > largest)
        {
            indices.Clear();
            largest = x.value;
        }
        // if unsorted
        //if (x.value == largest) indices.Add(x.idx);
        // if sorted you don't need to check against largest
        indices.Add(x.idx);
    }
    Console.WriteLine("largest = {0}; indices = {1}", largest, string.Join(", ", indices));
