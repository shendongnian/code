    internal class Data
    {
        public string UId { get; set; }
        public string Status { get; set; }
        public Data(string text)
        {
            string strRegex = @"<uid>(.*?)</uid>.*?<status>(.*?)</status>";
            Regex myRegex = new Regex(strRegex, RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            var match = myRegex.Match(text);
            UId = match.Groups[1].Value;
            Status = match.Groups[2].Value;
        }
    }
