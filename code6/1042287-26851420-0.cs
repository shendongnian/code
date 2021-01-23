    IEnumerable<Day> collection = asc ? calendar : calendar.Reverse();
    for (int i = 0; i < calendar.Length; i++)
    {
        collection.ElemantAt(i);// This is the current element
    }
    
    //Or better, you are getting everything anyways:
    foreach (Day day in collection)
    {
    }
