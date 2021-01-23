    var first = new Dictionary<int, int>();      // Stores the first instance of each value and its index
    var duplicates = new Dictionary<int, int>(); // Stores any subsequent instances with the previous index
    for(int i = 0; i < in_number.Length; i++)
    {
        if (!first.ContainsKey(in_number[i]))
        {
            first.Add(in_number[i], i);
        } 
        else if (!duplicates.ContainsKey(in_number[i]))
        {
            duplicates.Add(in_number[i], first[in_number[i]]);
        }
    }
