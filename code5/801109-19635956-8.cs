    return Directory.GetFiles(folderPath, "*.xml")
       .Select(XDocument.Load)
       .SelectMany(file => file.Descendants().Where(e => e.Name.LocalName == "FilingLeadDocument").Concat(file.Descendants().Where(e => e.Name.LocalName == "FilingConnectedDocument")))
       .Select(documentNode =>
       {
          var receivedDateNode = documentNode.Elements().FirstOrDefault(e => e.Name.LocalName == "DocumentReceivedDate");
          var descriptionNode = documentNode.Elements().FirstOrDefault(e => e.Name.LocalName == "DocumentDescriptionText");
          var metadataNode = documentNode.Elements().FirstOrDefault(e => e.Name.LocalName == "DocumentMetadata");
          var registerActionNode = metadataNode.Elements().FirstOrDefault(e => e.Name.LocalName == "RegisterActionDescriptionText");
    
          return new object[]
          {
               (string)documentNode.Parent.Parent.Elements().FirstOrDefault(e => e.Name.LocalName == "DocumentIdentification"),
               (DateTime?)receivedDateNode.Elements().FirstOrDefault(e => e.Name.LocalName == "DateTime"),
               descriptionNode != null ? descriptionNode.Value.Trim() : string.Empty,
               registerActionNode != null ? registerActionNode.Value.Trim() : string.Empty
          };
       }).ToArray();
