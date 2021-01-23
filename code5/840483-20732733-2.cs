    int i = 0;
    while (CharactersInStringEnteredByUser.Count < 25)
    {
        if (i >= CharactersInAutomaticallyGeneratedString.Count)
            break;
        CharactersInStringEnteredByUser.Add(CharactersInAutomaticallyGeneratedString[i]);
        i++;
    }
