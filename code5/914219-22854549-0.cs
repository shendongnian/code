    public string PigLatinTranslator(string s)
            {
                s = Regex.Replace(s, @"(\b[a|e|i|o|u]\w+)", "$1way", RegexOptions.IgnoreCase);
                List<string> words = new List<string>();
                foreach (string v in s.Split(' '))
                {
                    string result;
                    if (!v.EndsWith("way"))
                    {
                        result = Regex.Replace(v, @"([^a|e|i|o|u]*)([a|e|i|o|u])(\w+)", "$2$3$1ay", RegexOptions.IgnoreCase);
                        words.Add(result);
                    }
                    else { words.Add(v); }
                }
                s = string.Join(" ", words);
                words.Clear();
                foreach (string v in s.Split(' '))
                {
                    string result = Regex.Replace(v, @"\b([^a|e|i|o|u]+)\b", "$1ay", RegexOptions.IgnoreCase);
                    words.Add(result);
                }
                s = string.Join(" ", words);
                return s;
            }
