    List<string> CharactersInStringEnteredByUser = new List<string>();
    List<string> CharactersInAutomaticallyGeneratedString = new List<string>();
    int i = 0;
    while (CharactersInStringEnteredByUser.Count < 25)
    {
        CharactersInStringEnteredByUser.Add(CharactersInAutomaticallyGeneratedString[i]);
        i++;
    }
