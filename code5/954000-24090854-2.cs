    using (var dictEnumerator = dictionary.GetEnumerator())
    {
        // No point in going any further if the dictionary is empty
        if (dictEnumerator.MoveNext())
        {
            foreach (var range in ranges)
            {
                bool endOfDict = false;
                var entry = dictEnumerator.Current;
                while (!endOfDict
                    && range.LowerBoundInclusive <= entry.Key
                    && range.UpperBoundExclusive > entry.Key)
                {
                    range.Total += entry.Value;
                    endOfDict = !dictEnumerator.MoveNext();
                    if (endOfDict)
                        break;
                    entry = dictEnumerator.Current;
                }
            }
        }
    }
