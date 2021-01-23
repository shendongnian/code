    for( int i = 0; i < list.Count; i+=5 )
    {
        list2.Add(new MyObject(
            list[i], 
            list.ElementAtOrDefault(i + 1),
            list.ElementAtOrDefault(i + 2),
            list.ElementAtOrDefault(i + 3), 
            list.ElementAtOrDefault(i + 4)));
    }
