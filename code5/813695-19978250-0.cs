    public static char returnSecondDuplicate(char[] arr)
    {
        if (arr.Length == 0)
            throw new ArgumentNullException("Empty Array passed");
        var dictionary = new Dictionary<char, int>();
        var duplicates = new List<char>();
        Char second = '\0';
        for (int i = 0; i <= arr.Length - 1; i++)
        {
            if (!dictionary.ContainsKey(arr[i]))
            {
                dictionary.Add(arr[i], 1);
            }
            else if (!duplicates.Contains(arr[i]))
            {
                duplicates.Add(arr[i]); // only add duplicates once (ignoring any duplicate duplicates!)
            }
            if (duplicates.Count == 2) // check to see if we are on the second duplicate
            {
                return arr[i]; // return early, we don't need to do anything else
            }
        }
        return second;
    }
