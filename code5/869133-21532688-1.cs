    //Extension method
    public static long MaxIndex(this SortedList<long, List<string>> list)
    {
        return list.Aggregate(
            new { MaxValue = -1, Key = -1L },
                ((agg, current) => (current.Value.Count.CompareTo(agg.MaxValue) > 0 || agg.Key == -1) ?
            new { MaxValue = current.Value.Count, Key = current.Key } :
            new { MaxValue = agg.MaxValue, Key = agg.Key })).
            Key;
    }
    // how the list is defined:
    var myList = new SortedList<long, List<string>>();
       
    // EXAMPLE data only:
    myList.Add(0, new List<string>());
    myList[0].AddRange(new[] { "a", "b", "c" });
        
    myList.Add(8, new List<string>());
    myList[8].AddRange(new[] { "1", "2" });
        
    myList.Add(23, new List<string>());
    myList[23].AddRange(new[] { "c", "d", "e", "f", "g" });
        
    var idx = myList.MaxIndex();
