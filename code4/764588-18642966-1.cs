    static void Main(string[] args)
    {
        string txt = @"Except oral wills, every will shall be in writing, 
    but may be handwritten or typewritten. The will shall contain the testator's 
    signature or by some other person in the testator's conscious presence and at the
    testator's express direction . The will shall be attested and subscribed in the
    conscious presence of the testator, by two or more competent witnesses, who saw the
    testator subscribe, or heard the testator acknowledge the testator's signature.
    For purposes of this section, conscious presence means within the range of any of the
    testator's senses, excluding the sense of sight or sound that is sensed by telephonic,
    electronic, or other distant communication.";
        //split string using common seperators - could add more or use regex.
        string[] words = txt.Split(',', '.', ';', ' ', '\n', '\r');
        //trim each tring and get rid of any empty ones
        words = words.Select(t=>t.Trim()).Where(t=>t.Trim()!=string.Empty).ToArray();
        const int MaxPhraseLength = 20;
        Dictionary<string, int> Counts = new Dictionary<string,int>();
        for (int phraseLen = MaxPhraseLength; phraseLen >= 2; phraseLen--)
        {
            for (int i = 0; i < words.Length - 1; i++)
            {
                //get the phrase to match based on phraselen
                string[] phrase = GetPhrase(words, i, phraseLen);
                string sphrase = string.Join(" ", phrase);
                Console.WriteLine("Phrase : {0}", sphrase);
                    
                int index = FindPhraseIndex(words, i+phrase.Length, phrase);
                if (index > -1)
                {
                    Console.WriteLine("Phrase : {0} found at {1}", sphrase, index);
                    
                    if(!Counts.ContainsKey(sphrase))
                        Counts.Add(sphrase, 1);
                    Counts[sphrase]++;
                }
            }
        }
        foreach (var foo in Counts)
        {
            Console.WriteLine("[{0}] - {1}", foo.Key, foo.Value);
        }
        Console.ReadKey();
    }
    static string[] GetPhrase(string[] words, int startpos, int len)
    {
        return words.Skip(startpos).Take(len).ToArray();
    }
    static int  FindPhraseIndex(string[] words, int startIndex, string[] matchWords)
    {
        for (int i = startIndex; i < words.Length; i++)
        {
            int j;
            for(j=0; j<matchWords.Length && (i+j)<words.Length; j++)
                if(matchWords[j]!=words[i+j])
                    break;
            
            if (j == matchWords.Length)
                return startIndex;
        }
        return -1;
    }
