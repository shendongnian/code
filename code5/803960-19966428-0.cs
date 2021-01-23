    var requestXML = request.ToString();
    var headerData = System.Text.Encoding.UTF8.GetBytes(requestXML);
      using (MemoryStream memoryStream = new MemoryStream(headerData))
      {
             using (XmlReader xmlReader = new XmlTextReader(memoryStream))
             {
                  xmlReader.MoveToContent();
                  while (xmlReader.Read())
                  {
                      if (xmlReader.NodeType == XmlNodeType.Element)
                      { 
                          //read whatever element is desired      
                      }
                   }
              }
        }
