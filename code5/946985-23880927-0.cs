    List<List<string>> myList = new List<List<string>>();
    myList.Add(new List<string> { "a", "b" });
    myList.Add(new List<string> { "c", "d", "e" });
    myList.Add(new List<string> { "qwerty", "asdf", "zxcv" });
    myList.Add(new List<string> { "a", "b" });
    
    // To iterate over it.
    foreach (List<string> subList in myList)
    {
        foreach (string item in subList)
        {
            Console.WriteLine(item);
        }
    }
