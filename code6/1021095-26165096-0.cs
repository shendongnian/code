     // These are the characters that are not allowing me to parse into a DateTime
     char[] charactersToRemove = new char[] 
     {
      (char)8206,
      (char)8207
     };
      // Removing the suspect characters
      foreach (char c in charactersToRemove)
      value = value.Replace((c).ToString(), "").Trim();
