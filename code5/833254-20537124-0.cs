    List<int> list1 = new List<int>() { 8, 2, 5, 1, 1 };
    List<int> list2 = new List<int>() { 3, 4, 1, 7, 4 };
    
    list2.InsertRange(0, list1.Take(3));
    list1.RemoveRange(0, 3);
    
    // 3 items have been inserted already, so we should skip them
    list1.InsertRange(0, list2.Skip(3).Take(3));
    list2.RemoveRange(3, 3);
