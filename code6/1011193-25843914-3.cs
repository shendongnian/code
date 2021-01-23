    public static IEnumerable<string> FindCommonWords(string str1, string str2, StringComparer comparer = null)
    {
        if (str1 == null)
            throw new ArgumentNullException("str1", "Both input strings must not be null!");
        if (str2 == null)
            throw new ArgumentNullException("str2", "Both input strings must not be null!");
        if (comparer == null) comparer = StringComparer.CurrentCulture;
        str1 = str1.Trim();
        str2 = str2.Trim();
        if(str1.Equals(Equals(str2, comparer)))
            return str1;
        string[] words1 = str1.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);
        string[] words2 = str2.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);
        if(Math.Min(words1.Length, words2.Length) < 2)
            return Enumerable.Empty<string>(); // one word is not supposed to be a commnon word sequence
        // use for-loop to find the longest common words
        for (int wordCount = words1.Length - 1; wordCount >= 2; wordCount--)
        {
            // scan word-count from left to right
            for (int skipCount = 0; wordCount + skipCount <= words1.Length; skipCount++)
            {
                // take wordCount-words from left side and walk from left to right
                IEnumerable<string> wordSeq = words1.Skip(skipCount).Take(wordCount);
                // search sequence in other words
                int indexInWords2 = words2.IndexOfSequence(wordSeq, comparer);
                if (indexInWords2 >= 0)
                {
                    // found match in other words, must be longest common sequence
                    return wordSeq;
                }
            }
        }
        return Enumerable.Empty<string>();
    }
