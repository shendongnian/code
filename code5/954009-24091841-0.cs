    List<KeyType> keys = dict.Keys.OrderBy(k => k).ToList();
    List<RangeType> ranges = rangeList.OrderBy(r => r.LowerBound).ToList();
    var iKey = 0;
    var iRange = 0;
    var count = 0;
    // do a merge
    while (iKey < keys.Count && iRange < ranges.Count)
    {
        if (keys[iKey] < ranges[i].LowerBound)
        {
            // key is smaller than current range's lower bound
            // move to next key
            ++iKey;
        }
        else if (keys[iKey] > ranges[i].UpperBound)
        {
            // key is larger than current range's upper bound
            // move to next range
            ++iRange;
        }
        else
        {
            // key is within this range
            ++count;
            ++iKey;
        }
    }
