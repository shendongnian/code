    using(var e1 = list1.GetEnumerator())
    using(var e2 = list2.GetEnumerator())
    {
        while(e1.MoveNext() && e2.MoveNext())
        {
             var item1 = e1.Current;
             var item2 = e2.Current;
    
             // use item1 and item2
        }
    }
    
