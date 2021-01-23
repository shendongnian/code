    var players = await GetPlayers();
---
    async Task<List<List<string>>> GetPlayers()
    {
        string url = "http://www.tibia.com/community/?subtopic=worlds&world=Antica";
        using (var client = new HttpClient())
        {
            var html = await client.GetStringAsync(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var table = doc.DocumentNode.SelectSingleNode("//table[@class='Table2']");
            return table.Descendants("tr")
                        .Skip(2)
                        .Select(tr => tr.Descendants("td")
                                        .Select(td => WebUtility.HtmlDecode(td.InnerText))
                                        .ToList())
                        .ToList();
        }
    }
