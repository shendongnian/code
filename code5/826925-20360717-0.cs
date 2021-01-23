    string longSentence = "This is a long sentence with more than 18 letters.";
    List<string> words = new List<string>();
    string currentSentence = string.Empty;
    var parts = longSentence.Split(' ');
    foreach (var part in parts)
    {
        if ((currentSentence + " " + part).Length < 18)
        {
            currentSentence += " " + part;
        }
        else
        {
            words.Add(currentSentence);
            currentSentence = part;
        }
    }
    words.Add(currentSentence);
    words[0] = words[0].TrimStart();
