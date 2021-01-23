    else
    {
        using (var iterator in GetEnumerator())
        {
            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }
        }
    }
