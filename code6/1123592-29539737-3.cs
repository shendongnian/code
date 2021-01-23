    List<string> words = new List<string>();
    words.Add("ABC");
    words.Add("elephant");
    words.Add("FLY");
    VowelChecker checker = new VowelChecker();
    foreach (string word in words)
    {
        Console.WriteLine("{0} contains a vowel: {1}", word, checker.ContainsVowel(word));
    }
    Console.ReadLine();
