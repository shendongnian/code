    var matchingWords = subject.Split()  // splits by spaces, tabs and new-lines
        .Where(word => sample.Length == word.Length
            && letters == string.Join("", word.TakeWhile(Char.IsLetter))
            && countDigits == word.SkipWhile(Char.IsLetter).TakeWhile(Char.IsDigit).Count());
    string word = matchingWords.FirstOrDefault();  // AB54925871
 
