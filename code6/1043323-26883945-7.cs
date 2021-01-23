    // note that the array now contains 4 consecutive 4, 4, 4, 4:
    int[] array = new int[] { 1, 1, 2, 3, 555, 4, 34, 4, 4, 4, 4, 6, 6, 888, 8, 8, 8, 8, 7, 7, 77,77 };
    var conseqEquals = array.GetConsecutiveEqual(); ;    
    int maxGroupCount = lookup.Max(g => g.Count());
    var allWithMaxCount = lookup.Where(g => g.Count() == maxGroupCount)
        .Select(mg => string.Join(",", mg));
    string allNums = string.Join(" | ", allWithMaxCount); // 4,4,4,4 | 8,8,8,8
