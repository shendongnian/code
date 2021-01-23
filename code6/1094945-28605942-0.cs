    public static int GetConsecutiveCharacterCount(this string input, int n)
    {
       // Does not contain expected number of characters
       if (input.Length < n)
          return 0;
    
       return Enumerable.Range(0, input.Length - (n - 1)) // Last n-1 characters will be covered in the last but one iteration.
                        .Where(x => Enumerable.Range(x, n).All(y => input[x] == input[y]) && // Check whether n consecutive characters match
                                    ((x - 1) > -1 ? input[x] != input[x - 1] : true) && // Compare the previous character where applicable
                                    ((x + n) < input.Length ? input[x] != input[x + n] : true) // Compare the next character where applicable
                         )
                        .Count();
    }
