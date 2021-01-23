    Dictionary<string, int> Words = new Dictionary<string, int>();
    string wordsList = "a list of words for testing a list of words for testing";
    foreach (string word in wordsList.Split(' '))
    {
       if (Words[word] == null)
          Words[word] = 1;
       else
          Words[word] += 1;
    }
    System.Console.WriteLine("testing: {0}", Words["testing"]); //result- testing: 2
