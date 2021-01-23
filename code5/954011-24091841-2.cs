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
            // here you could add this key to the list of keys not found in any range
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
            // add key to list of keys in this range
            ++iKey;
        }
    }
    // If there are leftover keys, then add them to the list of keys not found in a range
    while (iKey < keys.Count)
    {
        notFoundKeys.Add(keys[iKey]);
        ++iKey;
    }
