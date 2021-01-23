    static void Main(string[] args)
    {
        var sentence1 = "Mike is not your average guy. I think you are great.";
        var sentence2 = "Jim is not your friend. I think you are great.";
        var sentence3 = "Being different is not your fault. I think you are great.";
        //remove all punctuation 
        // http://stackoverflow.com/questions/421616
        sentence1 = new string(
          sentence1.Where(c => !char.IsPunctuation(c)).ToArray());
        sentence2 = new string(
          sentence2.Where(c => !char.IsPunctuation(c)).ToArray());
        sentence3 = new string(
          sentence3.Where(c => !char.IsPunctuation(c)).ToArray());
        //seperate into words
        var words1 = sentence1.Split(new char[] { ' ' },
          StringSplitOptions.RemoveEmptyEntries).ToList();
        var words2 = sentence2.Split(new char[] { ' ' },          
          StringSplitOptions.RemoveEmptyEntries).ToList();
        var words3 = sentence3.Split(new char[] { ' ' }, 
          StringSplitOptions.RemoveEmptyEntries).ToList();
        //create substring list
        var subSentence1 = CreateSubstrings(words1);
        var subSentence2 = CreateSubstrings(words2);
        var subSentence3 = CreateSubstrings(words3);
        //join then like a Sql Table
        var subSentences = subSentence1
            .Join(subSentence2,
                sub1 => sub1.Value,
                sub2 => sub2.Value,
                (sub1, sub2) => new { Sub1 = sub1, 
                                      Sub2 = sub2 })
            .Join(subSentence3,
                sub1 => sub1.Sub1.Value,
                sub2 => sub2.Value,
                (sub1, sub2) => new { Sub1 = sub1.Sub1, 
                                      Sub2 = sub1.Sub2, 
                                      Sub3 = sub2 })
            ;
        //Sorted by Lowest Index, then by Maximum Words
        subSentences = subSentences.OrderBy(s => s.Sub1.Rank)
          .ThenByDescending(s => s.Sub1.Length)
          .ToList();
        //Sort by Maximum Words, then Lowest Index
        /*subSentences = subSentences.OrderByDescending(s => s.Sub1.Length)
            .ThenBy(s => s.Sub1.Rank)
            .ToList();//*/
        foreach (var subSentence in subSentences)
        {
            Console.WriteLine(subSentence.Sub1.Length.ToString() + " " 
              + subSentence.Sub1.Value);
            Console.WriteLine(subSentence.Sub2.Length.ToString() + " " 
              + subSentence.Sub2.Value);
            Console.WriteLine(subSentence.Sub3.Length.ToString() + " " 
              + subSentence.Sub3.Value);
            Console.WriteLine("======================================");
        }
        Console.ReadKey();
    }
    //this could probably be done better -Erik
    internal static List<SubSentence> CreateSubstrings(List<string> words)
    {
        var result = new List<SubSentence>();
        for (int wordIndex = 0; wordIndex < words.Count; wordIndex++)
        {
            var sentence = new StringBuilder();
            int currentWord = wordIndex;
            while (currentWord < words.Count - 1)
            {
                sentence.Append(words.ElementAt(currentWord));
                result.Add(new SubSentence() { Rank = wordIndex, 
                  Value = sentence.ToString(), 
                  Length = currentWord - wordIndex + 1 });
                sentence.Append(' ');
                currentWord++;
            }
            sentence.Append(words.Last());
            result.Add(new SubSentence() { Rank = wordIndex, 
              Value = sentence.ToString(), 
              Length = words.Count - wordIndex });
        }
        return result;
    }
    internal class SubSentence
    {
        public int Rank { get; set; }
        public string Value { get; set; }
        public int Length { get; set; }
    }
