    Dictionary<char, List<string>> wordsByKey = GetDict(words);
    List<string> keyed;
    string word = "word";
    if (wordsByKey.TryGetValue(word[0], out keyed))
    {
        // same as before
    }
    else
    {
        wordsByKey.Add(word[0], new List<string>() { word }); // or not, again
                                                              // depending on whether you
                                                              // want the list to update.
    }
