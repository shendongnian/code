    var charList = new List<char> { 'A', 'B', 'C', 'E' };
    List<string> stringList = new List<string>();
    
    for (var i = 1; i < Math.Pow(2, charList.Count); i++)
    {
        var sb = new StringBuilder();
        for (var j = 0; j < charList.Count; j++)
        {
            int power = (int)Math.Pow(2, j);
            if ((i & power) == power) sb.Append(charList[j]);
        }
        var s = sb.ToString();
        if (s.Length > 1) stringList.Add(sb.ToString());
    }
    // Sort results.
    stringList.Sort((s1, s2) => s1.Length != s2.Length
        ? s1.Length.CompareTo(s2.Length) : s1.CompareTo(s2));
