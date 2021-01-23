    FindAndReplace(word, replacementKey, SequentialReplaceToken);
    var restOfText = replaceWithText;
    while (restOfText.Length > 20)
    {
        var firstTwentyChars = restOfText.Substring(0, 20);
        firstTwentyChars += SequentialReplaceToken;
        restOfText = restOfText.Substring(20);
        FindAndReplace(word, SequentialReplaceToken, firstTwentyChars);
    }
    FindAndReplace(word, SequentialReplaceToken, restOfText);
