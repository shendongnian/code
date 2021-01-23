    XElement data = XElement.Load(@"C:\Test.xml");
    var newsResults = data.Element("news")
                   .Descendants("news")
                   .Select(x => new
                   {
                       Name = (string)x.Attribute("name"),
                       Date = (DateTime)x.Attribute("date")
                   });
    foreach (var news in newsResults)
    {
        Console.WriteLine("News: {0}, Date: {1}", news.Name, news.Date);
    }
