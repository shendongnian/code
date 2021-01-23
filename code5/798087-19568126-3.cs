    private void DownloadRandomLink(string searchTerm)
    {
        string fullUrl = "http://www.google.com/#q=" + searchTerm;
        WebClient wc = new WebClient();
        wc.DownloadFile(fullUrl, "file.htm");
        Random rand = new Random();
        HtmlDocument doc = new HtmlDocument();
        doc.Load("file.htm");
        var linksOnPage = from lnks in doc.DocumentNode.Descendants()
                          where lnks.Name == "a" &&
                                lnks.Attributes["href"] != null &&
                                lnks.InnerText.Trim().Length > 0
                          select new
                              {
                                  Url = lnks.Attributes["href"].Value,
                                  Text = lnks.InnerText
                              };
        if (linksOnPage.Count() > 0)
        {
            int randomChoice = rand.Next(0, linksOnPage.Count()-1);
            var link = linksOnPage.Skip(randomChoice).First();
            // do something with link...
        }
    }
