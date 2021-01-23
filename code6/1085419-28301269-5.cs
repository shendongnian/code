        static void Main(string[] args)
        {
            TextWriter w = File.CreateText(@"C:\Users\drake\Desktop\NonDuplicateEmails.txt");
            ExtractEmails(@"C:\Users\drake\Desktop\New.txt", @"C:\Users\drake\Desktop\Email.txt");
            TextReader r = File.OpenText(@"C:\Users\drake\Desktop\Email.txt");
            RemovingAllDupes(r, w);
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
