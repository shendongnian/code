    List<int> original = new List<int> { 1, 4, 5, 3, 4, 10, 4, 12 };
    int sublistSize = 4; 
    // check if original size is greater than required sublistSize
    var sublists = Enumerable.Range(0, original.Count - sublistSize + 1)
                             .Select(i => original.GetRange(i, sublistSize));
