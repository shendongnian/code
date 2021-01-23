    const int maxLines = 5;
    string[] lines = Regex.Split(readableRss, "\r\n")
                       .Where(str => !string.IsNullOrEmpty(str))
                       .ToList();
    this.newsFeed1.NewsTextFeed = new string[maxLines];
    SetupText(lines
                 .Skip(Math.Max(0, collection.Count() - maxLines))
                 .Take(maxLines)
                 .ToArray());
