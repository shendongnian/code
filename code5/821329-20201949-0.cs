    // this generates all strings for characters 0-3 with lengths 2-3
    List<string> result = GenerateStrings("0123", 2, 3);
    private List<string> GenerateStrings(string allowedChars, int fromLength, int toLength)
    {
        List<string> strings = new List<string>();
        int charsNum = allowedChars.Length;
        for (int currentLength = fromLength; currentLength <= toLength; currentLength++)
        {
            // initialize array of indexes to generate individual characters
            int[] indexes = new int[currentLength];
            do
            {
                StringBuilder sb = new StringBuilder(currentLength);
                // generate characters based on current index values
                for (int charPosition = 0; charPosition < currentLength; charPosition++)
                {
                    sb.Append(allowedChars[indexes[charPosition]]);
                }
                strings.Add(sb.ToString());
                // until we can increment indexes array (still some character combinations available)
            } while (IncrementIndex(indexes, charsNum - 1, currentLength - 1));
        }
        return strings;
    }
    /// <summary>
    /// Have array of integer indexes such as [0,0,0] with valid values 0-9. 
    /// This function increments indexes from right by one with correct overflow handling, 
    /// such that value [0,0,3] is incremented to [0,0,4], value [0,2,9] to [0,3,0] etc.
    /// </summary>
    /// <returns>True if increment was successful, false if maximal value was reached.</returns>
    private bool IncrementIndex(int[] indexes, int maxItemValue, int incrementFromPosition)
    {
        indexes[incrementFromPosition]++;
        // check if current position overflow allowed range
        if (indexes[incrementFromPosition] > maxItemValue)
        {
            if (incrementFromPosition == 0)
            {
                // we reached left-most position and can't increment more
                return false;
            }
            indexes[incrementFromPosition] = 0;
            // increment next position to the left
            return IncrementIndex(indexes, maxItemValue, incrementFromPosition-1);
        }
        return true;
    }
