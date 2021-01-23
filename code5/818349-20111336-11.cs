            List<string> words = new List<string>{...};
            List<WordCount> foundWord = new List<WordCount>();
            foreach (string word in words)
            {
                WordCount match = foundWord.SingleOrDefault(w => w.wordDic == word);
                if (match!= null)
                {
                    match.count += 1;
                }
                else
                {
                    foundWord.Add(new WordCount { wordDic = word, count = 1 });
                }
            }
