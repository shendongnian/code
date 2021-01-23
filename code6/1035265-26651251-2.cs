    string html = webControl2.ExecuteJavascriptWithResult("document.getElementsByTagName('html')[0].innerHTML");
    var htmlDoc = new HtmlAgilityPack.HtmlDocument();
    htmlDoc.LoadHtml(html);
    var playerIds = new List<string>();
    var playerNodes = htmlDoc.DocumentNode.SelectNodes("//a[contains(@href, 'player.jsp?user=')]");
    if (playerNodes != null)
    {
        foreach (var playerNode in playerNodes)
        {
            string href = playerNode.Attributes["href"].Value;
            var parts = href.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1)
            {
                playerIds.Add(parts[1]);
            }
        }
    }
