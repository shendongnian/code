            public static bool Like(string pattern, string str)
            {
                string[] words = pattern.Split('*').Where(w => w.Trim() != string.Empty).ToArray();
    
                List<int> indeces = new List<int>();
    
                for (int i = 0, l = words.Length; i < l; i++)
                {
                    int wordIndex = str.IndexOf(words[i], StringComparison.OrdinalIgnoreCase);
    
                    if (wordIndex == -1)
                        return false;
                    else
                        indeces.Add(wordIndex);
                }
    
                List<int> sortedIndeces = indeces.ToList();
                sortedIndeces.Sort();
    
                for (int i = 0, l = sortedIndeces.Count; i < l; i++)
                {
                    if (sortedIndeces[i] != indeces[i]) return false;
                }
    
                return true;
            }
