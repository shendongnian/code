    var xmlDoc = new XmlDocument();
    // ... load it
    var bean = new Bean{ Containers = new List<Container>() };
    bean.FilePath = xmlDoc.SelectSingleNode("/bean/property[@name='documentName']")
                          .GetAttribute("value");
    int index = 1;
    foreach(XmlElement xmlContainer in xmlDoc.SelectNodes(
               "/bean/property[@name='containerNames']/list/value"))
    {
        var container = new Container
        { 
            Name  = xmlContainer.InnerText,
            Parts = new List<Part>()
        };
        foreach(XmlElement xmlPart in xmlDoc.SelectNodes(String.Format(
               "/bean/property[@name='partNames']/list/list[{0}]/value", index)))
        {
            var part = new Part{ Name = xmlPart.InnerText };
            container.Parts.Add(part);
        }
        bean.Containers.Add(container);
        index++;
    }
