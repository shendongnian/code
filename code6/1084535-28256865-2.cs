      var xmldoc = new XmlDocument();
      xmldoc.Load(Server.MapPath("~/rss.xml"));
      XmlNode channelNode = xmldoc.SelectSingleNode("descendant::channel");
      if (channelNode != null)
      {
        XmlNode item = xmldoc.CreateElement("item");
        XmlNode Title = xmldoc.CreateElement("title");
      Title.InnerText = "Title Text";
      item.AppendChild(Title);
      XmlNode link = xmldoc.CreateElement("link");
      link.InnerText = "http://www.example.com/.txt";
      item.AppendChild(link);
      XmlNode description = xmldoc.CreateElement("description");
      description.InnerText = "DESC";
      item.AppendChild(description);
      channelNode.AppendChild(item);
      }
      doc.Save(Server.MapPath("~/rss.xml"));
