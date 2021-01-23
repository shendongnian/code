    // how the list is defined:
    var myList = new SortedList<long, List<string>>();
       
    // EXAMPLE data only:
    myList.Add(0, new List<string>());
    myList[0].AddRange(new[] { "a", "b", "c" });
        
    myList.Add(8, new List<string>());
    myList[8].AddRange(new[] { "1", "2" });
        
    myList.Add(23, new List<string>());
    myList[23].AddRange(new[] { "c", "d", "e", "f", "g" });
        
    var m = myList.Aggregate((i1, i2) => i1.Value.Count > i2.Value.Count ? i1 );
