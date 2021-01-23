        static void Main(string[] args)
        {
            ExtractEmails(@"C:\Users\drake\Desktop\New.txt", @"C:\Users\drake\Desktop\Email.txt");
            var sr = new StreamReader(File.OpenRead(@"C:\Users\drake\Desktop\Email.txt"));
            var sw = new StreamWriter(File.OpenWrite(@"C:\Users\drake\Desktop\NonDuplicateEmails.txt"));
            RemovingAllDupes(sr, sw);
        }
        public static void RemovingAllDupes(StreamReader str, StreamWriter stw)
        {
            var lines = new HashSet<int>();
            while (!str.EndOfStream)
            {
                string line = str.ReadLine();
                int hc = line.GetHashCode();
                if (lines.Contains(hc))
                    continue;
                lines.Add(hc);
                stw.WriteLine(line);
            }
            stw.Flush();
            stw.Close();
            str.Close();
