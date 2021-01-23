    public static char returnSecondDuplicate(char[] arr)
    {
        if (arr.Length == 0)
            throw new ArgumentNullException("Empty Array passed");
        var dictionary = new Dictionary<char, int>();
        var duplicates = new List<char>();
        Char second = '\0';
        int i = 0;
		
        while (duplicates.Count != 2 && dictionary.Count != arr.Length)
        {
            if (!dictionary.ContainsKey(arr[i]))
                dictionary.Add(arr[i], 1);
            else if (!duplicates.Contains(arr[i]))
                duplicates.Add(arr[i]); // only add duplicates once (ignoring any duplicate duplicates!)
            second = duplicates.Count == 2 ? arr[i] : second;
            i++;
        }
        return second;
    }
