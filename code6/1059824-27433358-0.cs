    foreach (string fileNameXML in fileEntries)
    {
        //read 1 xml at a time.
        XmlDocument doc = new XmlDocument();
        doc.Load(fileNameXML);
        XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Job");
        foreach (XmlNode node in nodes)
        {
            var item = new MyItem(); // Whatever type _item was.
            
            item.Input = node.SelectSingleNode("Input").InnerText;
            item.OutputFolder = node.SelectSingleNode("OutputFolder").InnerText;
            item.OutputFile = node.SelectSingleNode("OutputFile").InnerText;
            item.Format = node.SelectSingleNode("Format").InnerText;
            item.Name = node.SelectSingleNode("Name").InnerText;
            item.Effects = node.SelectSingleNode("Effect").InnerText;
            item.Type = node.SelectSingleNode("Type").InnerText;
            item.Output = item.OutputFolder + item.OutputFile + "." + item.Format.ToLower();
           lstBoxQueue.Items.Add(item);
        }
    }
