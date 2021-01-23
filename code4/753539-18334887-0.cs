    private bool ValidateCharacters(string specialCharacters, AddressViewModel x)
    {
        return !x.Index.Any(specialCharacters.Contains) &&
               !x.Area.Any(specialCharacters.Contains);
    }
