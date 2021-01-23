    private async Task<string> covertRss(string url)
    {
        var s = await RssReader.Read(url);
        StringBuilder sb = new StringBuilder();
        foreach (RssNews rs in s)   //ERROR LINE
        {
            sb.AppendLine(rs.Title);
            sb.AppendLine(rs.PublicationDate);
            sb.AppendLine(rs.Description);
        }
        return sb.ToString();
    }
