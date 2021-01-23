    private static bool FindPortion(string input, string pattern)
    {
         if(!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(pattern))
              if(input.Contains(pattern))
                   return true;
    
         return false;
    }
