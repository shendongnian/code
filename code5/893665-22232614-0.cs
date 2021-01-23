    string password = "aA1%";
    HashSet<char> specialCharacters = new HashSet<char>() { '%', '$', '#' };
    if (password.Any(char.IsLower) && //Lower case 
         password.Any(char.IsUpper) &&
         password.Any(char.IsDigit) &&
         password.Any(specialCharacters.Contains))
    {
      //valid password
    }
