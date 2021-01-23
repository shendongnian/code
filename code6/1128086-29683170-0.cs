    using (var enumerator = enumerable.GetEnumerator())
    {
        while (enumerator.MoveNext())
        {
            var current = enumerator.Current;
            // use current.
        }
    }
