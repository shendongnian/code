        public static string[] ParseText(string text, int startPos, int endPos)
        {
            List<string> parsedText = new List<string>();
            string[] entries = null;
            if (startPos >= 0 && endPos > startPos)
            {
                string images = text.Substring(startPos + 1, endPos - 1);
                entries = images.Split(new[] { ',' });
                for (var i = 0; i < entries.Length; i++)
                {
                    entries[i] = entries[i].Replace("\"", "");
                }
                for (int i = 0; i < entries.Length; i++)
                {
                    parsedText.Add(entries[i]);
                }
            }
            return entries;
        }
