    class Program
    {
        static void Main(string[] args)
        {
            ExtractEmails(@"D:\New.txt", @"D:Email.txt");
        }
        public static void ExtractEmails(string inFilePath, string outFilePath)
        {
            string data = File.ReadAllText(inFilePath);
            Regex emailRegex = new Regex(@"^[w.%+\-]+@[\w.\-]+\.[A-Za-z]{2,6}$", RegexOptions.IgnoreCase);
            //(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            MatchCollection emailMatches = emailRegex.Matches(data);
            StringBuilder sb = new StringBuilder();
            foreach (Match emailMatch in emailMatches)
            {
                sb.AppendLine(emailMatch.Value);
            }
            File.WriteAllText(outFilePath, sb.ToString());
        }
    }
