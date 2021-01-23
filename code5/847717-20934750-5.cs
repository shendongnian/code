    const int rowLengthInChars = 6 * 20;
    const int totalNumberOfCharsToRead = rowLengthInChars * 6;
    
    char[] buffer = new char[totalNumberOfCharsToRead];
    using (StreamReader reader = new StreamReader("wt40.txt")
    {
        int numberOfCharsRead = reader.Read(buffer, 0, totalNumberOfCharsToRead);
    }
    // put them in your lists
    var list = buffer.ToList();
    List<char> l1 = list.Take(rowLengthInChars);
    List<char> l2 = list.Skip(rowLengthInChars).Take(rowLengthInChars);
    List<char> l3 = list.Skip(rowLengthInChars*2).Take(rowLengthInChars);
    // now a list of numbers using non LINQ method.
    List<string> list1 = new List<string>();
    int i = 0;
    StringBuilder sb = new StringBuilder();
    foreach(char c in l1)
    {
        if(i < 6)
        {
            sb.Append(c);
            i++;
        }
        i = 0;
        list1.Add(sb.ToString());
    }
    // parse to ints
    List<int> numbers1 = list1.Select(int.Parse);
    List<int> numbers2 = list2.Select(int.Parse);
    List<int> numbers3 = list3.Select(int.Parse);
