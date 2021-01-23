    foreach(var item in ListA.GroupBy(m=>m.ID).Where(x=>ListB.All(b=>b.ID != x.Key)))
    {
        counter ++;
        Debug.writeline(item.Key);
    }
