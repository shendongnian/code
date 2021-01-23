    private string PigLatinTranslator(string s)
        {
            s = Regex.Replace(s, @"(\b[a|e|i|o|u]\w+)", "$1way", RegexOptions.IgnoreCase);
            List<string> words = new List<string>();
            foreach (Match v in Regex.Matches(s, @"\w+"))
            {
                string result;
                if (!v.Value.EndsWith("way"))
                {
                    result = Regex.Replace(v.Value, @"([^a|e|i|o|u]*)([a|e|i|o|u])(\w+)", "$2$3$1ay", RegexOptions.IgnoreCase);
                    words.Add(result);
                }
                else { words.Add(v.Value); }
            }
            s = string.Join(" ", words);
            words.Clear();
            foreach (Match v in Regex.Matches(s,@"\w+"))
            {
                string result = Regex.Replace(v.Value, @"\b([^a|e|i|o|u]+)\b", "$1ay", RegexOptions.IgnoreCase);
                words.Add(result);
            }
            s = string.Join(" ", words);
            return s;
        }
