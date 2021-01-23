    HtmlNodeCollection table = htmlDocument.DocumentNode.SelectNodes("//tr");
    HtmlNodeCollection rows = table[0].SelectNodes("//td");
    for (int i = 0; i < rows.Count; ++i)
    {
        string flight = rows[i].InnerHtml.Trim();
        if (!flight.Contains(".jpg"))
        {
            item += flight + " - ";
        }
        else
        {
            lstFlights.Items.Add(item);
            item = "";
        }
     }
