        private static List<string> ParseLine(string yourString)
        {
            bool ignorePipe = false;
            string word = string.Empty;
            List<string> divided = new List<string>();
            foreach (char c in yourString)
            {
                if (c == '|' &&
                    !ignorePipe)
                {
                    divided.Add(word);
                    word = string.Empty;
                }
                else if (c == '"')
                {
                    ignorePipe = !ignorePipe;
                }
                else
                {
                    word += c;
                }
            }
            divided.Add(word);
            return divided;
        }
