    var foundChars = new SortedDictionary<char, int>();
    var stringBuilder = new StringBuilder();
    foreach (var c in originalString)
    {
        var count = 0;
        if (!foundChars.TryGetValue(c, out count)
        {
            foundChars.Add(c, 1);
        }
        else
        {
            count += 1;
            foundChars[c] = count;
        }
        stringBuilder.Append(c);
        if (count > 0) stringBuilder.Append(count);
    }
    
