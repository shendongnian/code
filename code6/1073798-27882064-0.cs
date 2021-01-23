    var description = item.SelectSingleNode("p").NextSibling.NextSibling;
    string a = string.Empty;
    while (description != item.SelectNodes("p")[1])
    {
        a += description.InnerText + Environment.NewLine + Environment.NewLine;
        description = description.NextSibling;
    }
    apod.Description = a;
