    // Ignore all whitespace within the expression.
    infixExp = Regex.Replace(infixExp, @"\s+", String.Empty);
            
    // Seperate the expression based on the tokens (, ), +, -, 
    // *, /, and ignore any of the empty Strings that are added
    // due to duplicates.
    string[] substrings = Regex.Split(infixExp, @"([()+*/-])");
    substrings = substrings.Where(s => s != String.Empty).ToArray();
