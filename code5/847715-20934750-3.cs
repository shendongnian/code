    int rowLengthInChars = 6 * 20;
    int totalNumberOfCharsToRead = rowLengthInChars * 6;
    
    char[] buffer = new char[totalNumberOfCharsToRead];
    using (StreamReader reader = new StreamReader("wt40.txt")
    {
        int numberOfCharsRead = reader.Read(buffer, 0, totalNumberOfCharsToRead);
    }
    // put them in your lists
    var list = buffer.ToList();
    List<string> l1 = list.Take(20*6);
    List<string> l2 = list.Skip(20*6).Take(20*6);
    List<string> l3 = list.Skip(40*6).Take(20*6);
    // parse to ints
    List<int> numbers1 = l1.Select(int.Parse);
    List<int> numbers2 = l2.Select(int.Parse);
    List<int> numbers3 = l3.Select(int.Parse);
