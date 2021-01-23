     foreach (var letter in input)
     {
         if (!char.IsWhiteSpace(letter))
         {
             var letterKey = letter.ToString();
             
             if (dictionary.ContainsKey(letterKey))
             {
                 ++dictionary[letterKey];
             } 
             else
                 dictionary.Add(letterKey, 1);
        }
    } 
