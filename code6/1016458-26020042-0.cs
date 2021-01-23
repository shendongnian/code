    var trimmedLine = line.Trim();
    var tokens = trimmedLine.Split(space);
    trimmedLine = checkSymbol(tokens[0]);
    //look for the match, select the first (null if no matches)
    var matchedSymbol = mySymbols.FirstOrDefault(symName => symName.ToString() == trimmedLine);
                
    //if null (no match)                
    if (matchedSymbol == null)
    {
        throw new Exception(string.Format("ERROR - Symbol {0} not found in symbol table.", trimmedLine));
    }
    else
    {
        //print the match
        Console.WriteLine(string.Format("{0,-10} {1}", trimmedLine, matchedSymbol.value));
        //add the match to your collection of matches
        matchedSymbols.Add(matchedSybol);
    }
