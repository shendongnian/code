    string text = "   LOREM IPSUM DOLOR 0,5 SIT amet 0.3 consectetur adipiscing elit";
    string[] words = text.Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries);
    bool startUpper = words.First().All(Char.IsUpper);
    var firstSwitchingCaseWord = words
        .Select((word, index) => new { word, index })
        .FirstOrDefault(x => startUpper ? x.word.Any(Char.IsLower) : x.word.Any(Char.IsUpper));
    if (firstSwitchingCaseWord != null)
    {
        string firstPart = string.Join(" ", words.Take(firstSwitchingCaseWord.index));
        string lastPart  = string.Join(" ", words.Skip(firstSwitchingCaseWord.index));
    }
