    var reader = new XmlTextReader("path/to/myHtmlFile.html");
    while (reader.Read())
    {
      // Keep reading until we hit an element called iframe
      if (reader.NodeType == XmlNodeType.Element && reader.Name == "iframe")
      {
        while (reader.MoveToNextAttribute())
        {
          // Keep moving to the next attribute until we hit one called src
          if (reader.Name == "src")
          {
            return reader.Value;
          }
        }
      }
    }
