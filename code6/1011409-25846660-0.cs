    cursor.SetFlags(QueryFlags.NoCursorTimeout);
    using (var enumerator = cursor.GetEnumerator())
    {
        while (enumerator.MoveNext())
        {
            var item = enumerator.Current;
            // logic
            if (shouldPause)
            {
                Thread.Sleep(1000);
            }
        }
    }
