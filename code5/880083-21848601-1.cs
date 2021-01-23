    var input = "abcdefgabfabc";
    var counts = new Dictionary<char, int>();
    var sb = new StringBuilder();
    
    foreach (var c in input)
    {
        int count;
        counts.TryGetValue(c, out count);  // If "counts" doesn't have the key, then count will be 0
        counts[c] = ++count;
    
        sb.Append(c);
    
        if (count > 1)
            sb.Append(count);
    }
    
    var result = sb.ToString();
