    // ...
    var xmlDoc = new XElement("Stats",
        new XAttribute("Date", DateTime.Now.ToShortDateString()));
    XElement iteratingElement = null;
    var length = elementNames.Length + 1;
    for (int i = 0; i < cells.Count; i++)
    {
        if (i % ((i == 0) ? 1 : length) == 0)
        {
            iteratingElement = new XElement("Player",
                new XAttribute("Rank", cells[i]));
            xmlDoc.Add(iteratingElement);
        }
        else
        {
            iteratingElement
                .Add(new XElement(elementNames[(i % length) - 1], cells[i]));
        }
    }
    xmlDoc.Save("parsed.xml");
