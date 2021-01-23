      return Directory.GetFiles(folderPath, "*.xml")
           .Select(XDocument.Load)
           .SelectMany(file => file.Descendants().Where(e => e.Name.LocalName == "FilingLeadDocument").Concat(file.Descendants().Where(e => e.Name.LocalName == "FilingConnectedDocument")))
           .Select(documentNode =>
                  new object[]
                   {
                       (string)documentNode.Parent.Parent.Elements().FirstOrDefault(e => e.Name.LocalName == "DocumentIdentification"),
                       DateTime.Parse(documentNode.Elements().First(e => e.Name.LocalName == "DocumentReceivedDate").Elements().First(e => e.Name.LocalName == "DateTime").Value),
                       documentNode.Elements().First(e => e.Name.LocalName == "DocumentDescriptionText").Value.Trim(),
                       documentNode.Elements().First(e => e.Name.LocalName == "DocumentMetadata").Elements().First(e => e.Name.LocalName == "RegisterActionDescriptionText").Value.Trim(),
                    }).ToArray();
