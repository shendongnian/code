    List<Message> messagelist = XElement.Load(file)
        .Descendants("MESSAGE")
        .Select(e => new Message
        {
           From = e.Element("FROM").Value,
           Subject = e.Element("SUBJECT").Value,
           Record = string.Join("\n", e.Descendants("CONTENT")
                                       .Select(c => c.Value)
                                       .ToArray())
        }).ToList();
