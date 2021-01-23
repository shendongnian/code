    var charList = new List<char> { 'A', 'B', 'C', 'E' };
    List<string> stringList = new List<string>();
    
    for (var i = 0; i < Math.Pow(2, charList.Count); i++)
    {
        var sb = new StringBuilder();
        for (var j = 0; j < charList.Count; j++)
        {
            int power = (int)Math.Pow(2, j);
            if (i & power == 1) sb.Append(charList[j]);
        }
        stringList.Add(sb.ToString());
    }
