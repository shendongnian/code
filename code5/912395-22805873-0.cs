    using(var iter = {expression}.GetEnumerator())
    {
        while(iter.MoveNext()
        {
            SomeType name = iter.Current; // location on recent compilers
            // your code
        }
    }
