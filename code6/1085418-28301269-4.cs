        private static void RemovingAllDuplicates(TextReader r, TextWriter w)
        {
            throw new NotImplementedException();
        }
        public static void RemovingAllDupes(TextReader reader, TextWriter writer)
        {
            string currentLine;
            HashSet<string> previousLines = new HashSet<string>();
            while ((currentLine = reader.ReadLine()) != null)
            {
                // Add returns true if it was actually added,
                // false if it was already there
                if (previousLines.Add(currentLine))
                {
                    writer.WriteLine(currentLine);
                }
            }
            writer.Close();
        }
