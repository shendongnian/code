        public static void ExtractEmails(string inFilePath, string outFilePath)
        {
            string data = File.ReadAllText(inFilePath);
            Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            MatchCollection emailMatches = emailRegex.Matches(data);
            StringBuilder sb = new StringBuilder();
            foreach (Match emailMatch in emailMatches)
            {
                sb.AppendLine(emailMatch.Value);
            }
            File.WriteAllText(outFilePath, sb.ToString());
        }
