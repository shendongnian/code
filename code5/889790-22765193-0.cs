    internal static string ReverseItWithSurrogate(string stringToReverse)
    {
        string result = string.Empty;
    
        // We want to get the string into a character array first
        char[] stringArray = stringToReverse.ToCharArray();
    
        // This is the object that will hold our reversed string.
        var sb = new StringBuilder();
        bool haveSurrogate = false;
    
        // We are starting at the back and looking at each character.  if it is a
        // low surrogate and the one prior is a high and not < 0, then we have a surrogate pair.
        for (int loopVariable = stringArray.Length - 1; loopVariable >= 0; loopVariable--)
        {
        // we cant' check the high surrogate if the low surrogate is index 0
        if (loopVariable > 0)
        {
            haveSurrogate = false;
    
            if (char.IsLowSurrogate(stringArray[loopVariable]) &&    char.IsHighSurrogate(stringArray[loopVariable - 1]))
           {
              sb.Append(stringArray[loopVariable - 1]);
              sb.Append(stringArray[loopVariable]);
    
             // and force the second character to drop from our loop
             loopVariable--;
             haveSurrogate = true;
           }
    
          if (!haveSurrogate)
          {
             sb.Append(stringArray[loopVariable]);
            }
           }
        else
        {
         // Now we have to handle the first item in the list if it is not a high surrogate.
          if (!haveSurrogate)
          {
            sb.Append(stringArray[loopVariable]);
           }
         }
       }
    
    result = sb.ToString();
    return result;
    }
