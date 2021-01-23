    const int maxNumberDigitLength = 6;
    const int rowLengthInChars = maxNumberDigitLength * 20;
    const int totalNumberOfCharsToRead = rowLengthInChars * maxNumberDigitLength;
    
    char[] buffer = new char[totalNumberOfCharsToRead];
    using (StreamReader reader = new StreamReader("wt40.txt")
    {
        int numberOfCharsRead = reader.Read(buffer, 0, totalNumberOfCharsToRead);
    }
    // put them in your lists
    IEnumerable<char> l1 = buffer.Take(rowLengthInChars);
    IEnumerable<char> l2 = buffer.Skip(rowLengthInChars).Take(rowLengthInChars);
    IEnumerable<char> l3 = buffer.Skip(rowLengthInChars*2).Take(rowLengthInChars);
    // Get the list of strings from the list of chars using non LINQ method.
    List<string> list1 = new List<string>();
    int i = 0;
    StringBuilder sb = new StringBuilder();
    foreach(char c in l1)
    {
        if(i < maxNumberDigitLength)
        {
            sb.Append(c);
            i++;
        }
        i = 0;
        list1.Add(sb.ToString());
    }
    // LINQ method
    string s = string.Concat(l1);
    List<string> list1 = Enumerable
                       .Range(0, s.Length / maxNumberDigitLength)
                       .Select(i => s.Substring(i * maxNumberDigitLength, maxNumberDigitLength))
                       .ToList();     
    // Parse to ints using LINQ projection
    List<int> numbers1 = list1.Select(int.Parse);
    List<int> numbers2 = list2.Select(int.Parse);
    List<int> numbers3 = list3.Select(int.Parse);
