    using(var e = SomeYieldingMethod().GetEnumerator())
    {
        for (int i = 0; i< iterations; ++i) {
            Console.WriteLine(e.Current);
            e.MoveNext();
        }
    }
