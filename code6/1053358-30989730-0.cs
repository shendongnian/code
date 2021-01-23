    private static string[] getAllMeanings(Application wordApp, string word, int maxSize = 12,bool addOriginal = false)
        {
            List<string> stringArr = new List<string>();
            if (addOriginal)stringArr.Add(word);
            SynonymInfo theSynonyms = wordApp.SynonymInfo[word];
            foreach (var Meaning in theSynonyms.MeaningList as Array)
            {
                if (stringArr.Contains(Meaning) == false) stringArr.Add((string)Meaning);
            }
            for (int ii = 0; ii < stringArr.Count; ii++)
            {
                theSynonyms = wordApp.SynonymInfo[stringArr[ii]];
                foreach (string Meaning in theSynonyms.MeaningList as Array)
                {
                    if (stringArr.Contains(Meaning)) continue;
                    stringArr.Add(Meaning);
                }
                if (stringArr.Count >= maxSize) return stringArr.ToArray();
            }
            return stringArr.ToArray();
        }
