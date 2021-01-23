    // We're going to need finer control over the enumeration than foreach,
    // so we manipulate the enumerator directly instead.
    using (var dictEnumerator = dictionary.OrderBy(e => e.Key).GetEnumerator())
    {
        // No point in going any further if the dictionary is empty
        if (dictEnumerator.MoveNext())
        {
            long othersTotal = 0; // total for items that don't fall in any range
            // The ranges need to be in ascending order
            // We want the "others" range at the end
            foreach (var range in ranges.OrderBy(r => r.LowerBoundInclusive ?? int.MaxValue))
            {
                if (range.LowerBoundInclusive == null && range.UpperBoundExclusive == null)
                {
                    // this is the "others" range: use the precalculated total
                    // of previous items that didn't fall in any other range
                    range.Total = othersTotal;
                }
                else
                {
                    range.Total = 0;
                }
                
                int lower = range.LowerBoundInclusive ?? int.MinValue;
                int upper = range.UpperBoundExclusive ?? int.MaxValue;
            
                bool endOfDict = false;
                var entry = dictEnumerator.Current;
                
                // keys that are below the current range don't belong to any range
                // (or they would have been included in the previous range)
                while (!endOfDict && entry.Key < lower)
                {
                    othersTotal += entry.Value;
                    endOfDict = !dictEnumerator.MoveNext();
                    if (!endOfDict)
                        entry = dictEnumerator.Current;
                }
    
                // while the key in the the range, we keep adding the values
                while (!endOfDict  && lower <= entry.Key && upper > entry.Key)
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
