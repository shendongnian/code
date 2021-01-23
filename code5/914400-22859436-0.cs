    public XPathNodeIterator GetInspectionTime (...) 
    {
      XmlDocument doc = new XmlDocument();
      doc.AppendChild(doc.CreateElement("root"));
      foreach (string value in yourArray) 
      {
        XmlElement item = doc.CreateElement("item");
        item.InnerText = value;
        doc.DocumentElement.AppendChild(item);
      }
      return doc.CreateNavigator().Select("/root/item");
    }
