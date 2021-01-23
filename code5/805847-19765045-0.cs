    // ...
    var xmlDoc = new XElement("Stats", 
        new XAttribute("Date", DateTime.Now.ToShortDateString()));
    XElement iteratingElement = null;
    for (int i = 0; i < cells.Count; i++)
    {
        if (i % ((i == 0) ? 1 : (elementNames.Length + 1)) == 0)
        {
            iteratingElement = new XElement("Player", 
                new XAttribute("Rank", cells[i]));
            xmlDoc.Add(iteratingElement);
        }
        else
        {
            iteratingElement.Add(new XElement(elementNames[(i % 19) - 1], cells[i]));
        }
    }
    xmlDoc.Save("parsed.xml");
