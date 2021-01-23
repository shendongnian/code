    var list1 = new[] { 2, 3 };
    var list2 = new[] { 1, 2, 4, 5 };
    var excepts = list1.Except(list2);
    var union = list1.Union(list2);
    var newlist = union.Except(excepts);
    Console.WriteLine(string.Join(",", newlist));
