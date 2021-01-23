    var input = @" a , b;whatever";
    // The \G anchor ensures the next match begins where the last ended.
    // Then non-greedily (as in don't eat the separators) try to find a value.
    // Finally match a separator.
    var matches = Regex.Matches(input, @"\G(.*?)([,;])")
    	.OfType<Match>();
    
    // All the matches, deal with pairs as appropriate - here I simply group
    // them into strings, but build a List of Pairs or whatnot.
    var res = matches
    	.Select(m => "{" + m.Groups[1].Value + "|" + m.Groups[2].Value + "}");
    // res -> Enumerable with "{ a |,}", "{ b|;}" 
    
    String trailing;
    var lastMatch = matches.LastOrDefault();
    if (lastMatch != null) {
    	trailing = input.Substring(lastMatch.Index + lastMatch.Length);
        // If the separator was at the end, trailing is an empty string
    } else {
        // No matches, the entire input is trailing.
        trailing = input;
    }
    // trailing -> "whatever"
