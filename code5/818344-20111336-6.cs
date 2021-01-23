            List<string> words = new List<string>{...};
            List<string> foundWord = new List<string>();
            List<int> countWord = new List<int>();
            foreach (string word in words)
            {
                if (foundWord.Contains(word))
                {
                    countWord[foundWord.IndexOf(word)] += 1;
                }
                else
                {
                    foundWord.Add(word);
                    countWord[foundWord.IndexOf(word)] = 1;
                }
            }
