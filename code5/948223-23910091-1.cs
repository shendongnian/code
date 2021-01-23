    var myLists = new List<List<T>>(); // T is the generic type of your Lists, obviously
    myLists.Add(list1);
    myLists.Add(list2);
    ...
    myLists.Add(listN);
    // iterate over the largest one:
    foreach (var item in myLists.First(l => l.Count == lists.Max(x=>x.Count)))
    {
        // do stuff
    }
