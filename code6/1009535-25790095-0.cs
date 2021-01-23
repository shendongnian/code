    string test = "blah blah blahtestblah blahtestblah";
    string[] splits = test.Split(new string[] { "test" }, StringSplitOptions.RemoveEmptyEntries);
    int nMessages = splits.Length;
    int nWords = 0, nLetters = 0;
    foreach (string str in splits)
    {
        Console.WriteLine(str);
        nWords += str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        nLetters += str.Length;
    }
    Console.WriteLine("That was {0} messages in {1} words and {2} letters", nMessages, nWords, nLetters);
