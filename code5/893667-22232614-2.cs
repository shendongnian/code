    int conditionsCount = 0;
    if (password.Any(char.IsLower))
        conditionsCount++;
    if (password.Any(char.IsUpper))
        conditionsCount++;
    if (password.Any(char.IsDigit))
        conditionsCount++;
    if (password.Any(specialCharacters.Contains))
        conditionsCount++;
    if (conditionsCount >= 3)
    {
        //valid password
    }
