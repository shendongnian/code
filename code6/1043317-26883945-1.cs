    int[] array = new int[] { 1, 1, 2, 3, 555, 4, 34, 4, 4, 4, 6, 6, 888, 8, 8, 8, 8, 7, 7, 77,77 };
    var conseqEquals = array.GetConsecutiveEqual(); ;    
    var lookup = conseqEquals.ToLookup(i => i);
    var maxGroup = lookup.OrderByDescending(g => g.Count()).First();
    string allNums = string.Join(",", maxGroup); // 8,8,8,8
