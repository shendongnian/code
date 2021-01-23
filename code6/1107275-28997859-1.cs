    Boolean IsAcceptableWord2(String input, Char yellowLetter, params Char[] textBoxLetters)
    {
        // Short-circuit: must not be empty
        if (String.IsNullOrEmpty(input))
        {
            return false;
        }
        
        // Validation
        if (textBoxLetters == null || textBoxLetters.Length == 0)
        {
            throw new ArgumentNullException("textBoxLetters");
        }
        if (!Char.IsLetter(yellowLetter))
        {
            throw new ArgumentException("Must be a letter", "yellowLetter");
        }
        if (textBoxLetters.Any(x => !Char.IsLetter(x)))
        {
            throw new ArgumentException("Must be all letters", "textBoxLetters");
        }
        
        // Normalization
        input = input.ToLowerInvariant();
        yellowLetter = Char.ToLower(yellowLetter);
        textBoxLetters = textBoxLetters.Select(x => Char.ToLower(x)).ToArray();
        var inputCharArray = input.ToCharArray();
        
        // Comparisons
        var yellowLetterCount = inputCharArray.Count(x => x == yellowLetter);
        if (yellowLetterCount != 1)
        {
            return false;
        }
        var remainingInputLetters = inputCharArray.Where(x => x != yellowLetter).ToList();
        foreach (var textBoxLetter in textBoxLetters)
        {
            var i = remainingInputLetters.IndexOf(textBoxLetter);
            if (i > -1)
            {
                remainingInputLetters.RemoveAt(i);
            }
        }
        return (remainingInputLetters.Count == 0);
    }
