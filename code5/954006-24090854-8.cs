    // We're going to need finer control over the enumeration than foreach,
    // so we manipulate the enumerator directly instead.
    using (var dictEnumerator = dictionary.OrderBy(e => e.Key).GetEnumerator())
    {
        // No point in going any further if the dictionary is empty
        if (dictEnumerator.MoveNext())
        {
            // The ranges need to be in ascending order
            foreach (var range in ranges.OrderBy(r => r.LowerBoundInclusive))
            {
                bool endOfDict = false;
                var entry = dictEnumerator.Current;
                range.Total = 0;
                // while the key in the the range, we keep adding the values
                while (!endOfDict
                    && range.LowerBoundInclusive <= entry.Key
                    && range.UpperBoundExclusive > entry.Key)
                {
                    range.Total += entry.Value;
                    endOfDict = !dictEnumerator.MoveNext();
                    if (!endOfDict)
                        entry = dictEnumerator.Current;
                }
                if (endOfDict) // No more entries in the dictionary, no need to go further
                    break;
                // the value of the current entry is now outside the range,
                // so carry on to the next range
            }
        }
    }
