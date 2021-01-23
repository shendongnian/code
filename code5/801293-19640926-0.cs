        Dictionary<char, int> LetterCount(string textPath)
        {
            var dic = new Dictionary<char, int>();
            foreach (char c in System.IO.File.ReadAllText(textPath))
            {
                if (dic.ContainsKey(c))
                    dic[c]++;
                else
                    dic.Add(c, 1);
            }
            return dic;
        }
