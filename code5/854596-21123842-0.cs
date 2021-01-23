    using(var iter = sequence.GetEnumerator())
    {
        while(iter.MoveNext())
        {
            var x = iter.Current;
            // ...
        }
    }
