        var names = DocumentNode.SelectNodes("//td[@class='sivo']");
    var links = DocumentNode.SelectNodes("//td[@class='sivo']/a");
        foreach (item in nodes)
        {
        Console.WriteLine (item.InnerText); //name
        }
    foreach (item in links)
    {
    Console.WriteLine(item.Attributes["href"]);//links
    Console.WriteLine(item.InnerText);  //time
    }
