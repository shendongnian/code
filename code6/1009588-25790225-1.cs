    foreach (XNode node in XmlLst.Element("parent").DescendantNodes())
    {
        if (node is XElement)
        {
            thingy = (basefp + ((XElement)node).Value);
            Thingylist.Add(mibbler);
        }
        else
        {
            // do something else
        }
    }
