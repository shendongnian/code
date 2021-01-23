    List<string> list1 = new List<string>();
    List<string> list2 = new List<string>();
    List<string> list3 = new List<string>();
    List<string> list4 = new List<string>();
    //Populate the lists
    var mergedList = list1.Concat(list2)
        .Concat(list3)
        .Concat(list4)
        .ToList();
