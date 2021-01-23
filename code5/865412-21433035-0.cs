    using(var iter = GetItemDetails(item).GetEnumerator())
    {
        while(iter.MoveNext()
        {
            var item = iter.Current;
            // ...
        }
    }
