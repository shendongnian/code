    for (int i = 0; i < myString.Length && !(hasUpper && hasLower && hasDigit); i++)
    {
        char c = myString[i];
        if (!hasUpper) hasUpper = char.IsUpper(c);
        if (!hasLower) hasLower = char.IsLower(c);
        if (!hasDigit) hasDigit = char.IsDigit(c);
    }
    bool valid = hasUpper && hasLower && hasDigit;
