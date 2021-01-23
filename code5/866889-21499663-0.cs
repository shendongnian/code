    using (var enumerator = collection.GetEnumerator())
    {
        while (enumerator.MoveNext())
        {
            var item = enumerator.Current;
            // loop contents here
        }
    }
