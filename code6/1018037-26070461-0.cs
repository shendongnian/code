    Parallel.ForEach(stringToCount, character =>
    {
        if (char.IsControl(character))
        {
            //Interlocked.Increment gives you a thread safe ++
            Interlocked.Increment(controlCount);
        }
        if (char.IsDigit(character))
        {
            Interlocked.Increment(digitCount);
        }
        if (char.IsLetter(character))
        {
            Interlocked.Increment(letterCount);
        } //etc.
    });
    var result = new CharacterCountResult(controlCount, highSurrogatecount, lowSurrogateCount, whiteSpaceCount,
        symbolCount, punctuationCount, separatorCount, letterCount, digitCount, numberCount, letterAndDigitCount,
        lowercaseCount, upperCaseCount, tempDictionary);
