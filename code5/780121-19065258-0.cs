    var array = new[] { 16, 5, 23, 1, 19 };
    var indices = Enumerable.Range(0, array.Length).ToArray();
    Array.Sort(array, indices);
    var result = new int[array.Length];
    for (int i = 0; i < result.Length; ++i)
        result[indices[i]] = i;
    // Now result[] contains the answer.
