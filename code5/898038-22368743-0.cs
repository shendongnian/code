        private static IEnumerable<string> SplitToLines(string value, int maximumLineLength)
        {
            var words = value.Split(' ');
            var line = new StringBuilder();
            
            foreach (var word in words)
            {
                if ((line.Length + word.Length) >= maximumLineLength)
                {
                    yield return line.ToString();
                    line = new StringBuilder();
                }
                line.AppendFormat(" {0}", word);
            }
        }
