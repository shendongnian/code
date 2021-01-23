    string cleanedLine = System.Text.RegularExpressions.Regex.Replace(line,@"\s+"," ");
    if (Comparer.ContainsKey( cleanedLine ))
        Comparer[ cleanedLine ] ++;
    else
        Comparer[ cleanedLine ] = 1;
