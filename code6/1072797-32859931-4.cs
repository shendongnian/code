        private List<string> GetUrls(string html)
        {
            var urls = new List<string>();
            string search = @",""ou"":""(.*?)"",";
            MatchCollection matches = Regex.Matches(html, search);
            foreach (Match match in matches)
            {
                urls.Add(match.Groups[1].Value);
            }
            return urls;
        }
