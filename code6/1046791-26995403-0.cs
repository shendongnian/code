    var list  = new List<MyObject>{ ... };
    var list2 = new List<MyObject>();
    for( int i = 0; i + 5 <= list.Count; i+=5 )
    {
        list2.Add(new MyObject(list[i], list[i + 1], list[i + 2], list[i + 3], list[i + 4]));
    }
