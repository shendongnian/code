        public static IEnumerable<string> SplitString(this string sInput, char search, int maxlength)
        {
            var result = new List<string>();
            var count = 0;
            var lastSplit = 0;
            foreach (char c in sInput)
            {
                if (c == search || count - lastSplit == maxlength)
                {
                    result.Add(sInput.Substring(lastSplit, count - lastSplit));
                    lastSplit = count;
                }
                
                count ++;
            }
            result.Add(sInput.Substring(lastSplit, count - lastSplit));
            return result;
        }
