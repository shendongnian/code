        private static void ReduceToDifferences(IList<string> wordsA, IList<string> wordsB)
        {
            // Maybe there's some optimization possible, 
            // e.g. loop over the list with fewest entries or something
            for (int i = wordsA.Count - 1; i >= 0; i--)
            {
                // Find word of list A in list B
                var word = wordsA[i];
                var index = wordsB.IndexOf(word);
                // If found, remove it in both
                if (index > -1)
                {
                    wordsB.RemoveAt(index);
                    wordsA.RemoveAt(i);
                }
            }
        }
		
