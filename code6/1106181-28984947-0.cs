    public static string GetNextLetter(string letter = null)
    {
         if (IsStringNullOrEmpty(letter))
             return "A";
         char lastLetter = letter.Last();
         if (lastLetter.ToString() == "Z")
             return GetNextLetter(RemoveLastCharacter(letter)) + "A";
         else
             return RemoveLastCharacter(letter) + (char)(lastLetter + 1);
        }
