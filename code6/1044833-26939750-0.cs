    using (FileStream fs = new FileStream("Links.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)_
    using (StreamWriter writer = new StreamWriter(fs))
    {
        string url;
        HtmlWeb web = new HtmlWeb();
        for (int i = 0; i < 26; i++)
        {
            char c = (char)('A' + i);
            HtmlDocument doc = web.Load(@"https://www2.aus.edu/facultybios/index.php?sort=" + c);
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                url = link.Attributes["href"].Value.ToString();
                if (url.Length > 25 &&
                    url.Substring(0, 25).Equals(@"/facultybios/profile.php?", StringComparison.Ordinal))
                {
                    writer.WriteLine(@"https://www2.aus.edu" + url);
                    writer.Flush();
                }
            }
        }
    }
